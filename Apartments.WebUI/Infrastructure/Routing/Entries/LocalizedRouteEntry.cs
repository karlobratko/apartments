using System;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace Apartments.WebUI.Infrastructure.Routing.Entries {
  public class LocalizedRouteEntry : RouteEntry {
    public LocalizedRouteEntry(String name,
                               Route route,
                               String explicitCulture,
                               Boolean translateUrl)
        : base(name, route) {
      ExplicitCulture = explicitCulture;
      TranslateUrl = translateUrl;
    }

    public String ExplicitCulture { get; }
    public Boolean TranslateUrl { get; }
  }
}