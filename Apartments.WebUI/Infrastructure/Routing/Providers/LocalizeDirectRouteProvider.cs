using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

using Apartments.WebUI.Infrastructure.Routing.Constraints;
using Apartments.WebUI.Infrastructure.Routing.Entries;

namespace Apartments.WebUI.Infrastructure.Routing.Providers {
  public class LocalizeDirectRouteProvider : DefaultDirectRouteProvider {
    private readonly String _urlPrefix;
    private readonly String _defaultCulture;
    private readonly String[] _allCultures;
    private readonly Boolean _prefixDefaultCulture = false;

    private readonly RouteValueDictionary _constraints;

    public LocalizeDirectRouteProvider(String urlPrefix, String defaultCulture, String[] allCultures) {
      _urlPrefix = urlPrefix;
      _defaultCulture = defaultCulture;
      _allCultures = allCultures;

      Array.Sort(array: _allCultures, comparison: (x, y) => x == defaultCulture ? 1 : x.CompareTo(y));

      _constraints = new RouteValueDictionary {
        { "culture", new CultureConstraint(defaultCulture: defaultCulture) }
      };
      _prefixDefaultCulture = Boolean.Parse(value: ConfigurationManager.AppSettings["PrefixDefaultCulture"]);
    }

    protected override IReadOnlyList<RouteEntry> GetActionDirectRoutes(ActionDescriptor actionDescriptor,
                                                                       IReadOnlyList<IDirectRouteFactory> factories,
                                                                       IInlineConstraintResolver constraintResolver) {
      IReadOnlyList<RouteEntry> originalEntries = base.GetActionDirectRoutes(actionDescriptor, factories, constraintResolver);
      var finalEntries = new List<RouteEntry>();

      foreach (RouteEntry originalEntry in originalEntries) {
        String explicitCulture = "";
        Boolean translateUrl = false;

        if (originalEntry is LocalizedRouteEntry asLocalizedRouteEntry) {
          explicitCulture = asLocalizedRouteEntry.ExplicitCulture;
          translateUrl = asLocalizedRouteEntry.TranslateUrl;
        }

        if (explicitCulture != "") {
          RouteEntry newEntry = CreateExplicitCultureRouteEntry(originalEntry,
                                                                explicitCulture,
                                                                translateUrl);
          finalEntries.Add(newEntry);
        }
        else {
          if (!translateUrl) {
            Route localizedRoute = CreateLocalizedRoute(originalEntry.Route, _urlPrefix, new RouteValueDictionary(), _constraints, "");
            RouteEntry localizedRouteEntry = CreateLocalizedRouteEntry(originalEntry.Name, localizedRoute);
            finalEntries.Add(localizedRouteEntry);
            originalEntry.Route.Defaults.Add("culture", _defaultCulture);
            finalEntries.Add(originalEntry);
          }
          else {
            foreach (String culture in _allCultures) {
              RouteEntry newEntry = CreateExplicitCultureRouteEntry(originalEntry, culture, true);
              finalEntries.Add(newEntry);
            }
          }
        }
      }

      return finalEntries;
    }

    private RouteEntry CreateExplicitCultureRouteEntry(RouteEntry originalEntry,
                                                       String culture,
                                                       Boolean translateUrl) {
      Boolean cultureIsDefault = culture == _defaultCulture;
      Route route = CreateLocalizedRoute(route: originalEntry.Route,
                                         urlPrefix: cultureIsDefault && !_prefixDefaultCulture ? "" : _urlPrefix,
                                         defaults: cultureIsDefault
                                           ? new RouteValueDictionary {
                                             { "culture", culture }
                                           }
                                           : new RouteValueDictionary(),
                                         constraints: cultureIsDefault
                                           ? new RouteValueDictionary()
                                           : new RouteValueDictionary {
                                             { "culture", culture }
                                           },
                                         translateForCulture: translateUrl ? culture : "");
      return cultureIsDefault
        ? new RouteEntry(originalEntry.Name, route)
        : CreateLocalizedRouteEntry(name: originalEntry.Name,
                                    route: route,
                                    explicitCulture: culture);
    }

    private Route CreateLocalizedRoute(Route route,
                                       String urlPrefix,
                                       RouteValueDictionary defaults,
                                       RouteValueDictionary constraints,
                                       String translateForCulture) {
      String routeUrl = String.IsNullOrEmpty(translateForCulture)
        ? route.Url
        : TranslateUrl(url: route.Url,
                       culture: translateForCulture);

      String culturePrefixedUrl = urlPrefix + routeUrl;
      var routeDefaults = new RouteValueDictionary(defaults);
      foreach (KeyValuePair<String, Object> def in route.Defaults) {
        routeDefaults.Add(def.Key, def.Value);
      }

      var routeConstraints = new RouteValueDictionary(constraints);
      foreach (KeyValuePair<String, Object> constraint in route.Constraints) {
        routeConstraints.Add(constraint.Key, constraint.Value);
      }

      return new Route(url: culturePrefixedUrl,
                       defaults: routeDefaults,
                       constraints: routeConstraints,
                       dataTokens: route.DataTokens,
                       routeHandler: route.RouteHandler);
    }

    private String TranslateUrl(String url, String culture) {
      String[] parts = url.Split('/');
      foreach (String part in parts) {
        if (part.StartsWith("{"))
          continue;

        String translatedPart = Resources.Global.TranslatedUrls.ResourceManager.GetString(name: part,
                                                                                          culture: new CultureInfo(culture));
        if (String.IsNullOrEmpty(translatedPart))
          throw new Exception($"Could not find translation for url part {part} for culture {culture}");
        url = url.Replace(part, translatedPart);
      }

      return url;
    }

    private RouteEntry CreateLocalizedRouteEntry(String name, Route route, String explicitCulture = "") {
      String suffix = String.IsNullOrEmpty(explicitCulture)
        ? String.Empty
        : $"_{explicitCulture}";

      String localizedRouteEntryName = String.IsNullOrEmpty(name)
        ? null
        : $"{name}_Localized{suffix}";

      return new RouteEntry(localizedRouteEntryName, route);
    }
  }
}