using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;

namespace Apartments.WebUI.Infrastructure.Routing.Constraints {
  public class CultureConstraint : IRouteConstraint {
    private const String DEFAULT_PATTERN = "[a-z]{2}";

    private readonly String _defaultCulture;
    private readonly String _pattern;

    public CultureConstraint(String defaultCulture)
      : this(defaultCulture, DEFAULT_PATTERN) {
    }

    public CultureConstraint(String defaultCulture, String pattern) {
      _defaultCulture = defaultCulture;
      _pattern = pattern;
    }

    public Boolean Match(HttpContextBase httpContext,
                         Route route,
                         String parameterName,
                         RouteValueDictionary values,
                         RouteDirection routeDirection)
      => (
           routeDirection != RouteDirection.UrlGeneration ||
           !_defaultCulture.Equals(values[parameterName])
         ) &&
         Regex.IsMatch(values[parameterName].ToString(), $"^{_pattern}$");
  }
}