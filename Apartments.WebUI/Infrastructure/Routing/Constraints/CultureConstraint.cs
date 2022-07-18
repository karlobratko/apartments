using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;

namespace Apartments.WebUI.Infrastructure.Routing.Constraints {
  public class CultureConstraint : IRouteConstraint {
    private static readonly Regex CULTURE_REGEX = new Regex("^[a-z]{2}$");

    private readonly String _defaultCulture;

    public CultureConstraint(String defaultCulture) => _defaultCulture = defaultCulture;

    public Boolean Match(HttpContextBase httpContext,
                         Route route,
                         String parameterName,
                         RouteValueDictionary values,
                         RouteDirection routeDirection)
      => (
           routeDirection != RouteDirection.UrlGeneration ||
           !_defaultCulture.Equals(values[parameterName])
         ) &&
         CULTURE_REGEX.IsMatch(input: values[parameterName].ToString());
  }
}