using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

using Apartments.WebUI.Infrastructure.Routing.Constraints;

namespace Apartments.WebUI {
  public class RouteConfig {
    public static void RegisterRoutes(RouteCollection routes) {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
      routes.LowercaseUrls = true;

      _ = routes.MapRoute(name: "DefaultWithCulture",
                          url: "{culture}/{controller}/{action}/{id}",
                          defaults: new {
                            controller = "Home",
                            action = "Index",
                            id = UrlParameter.Optional
                          },
                          constraints: new {
                            culture = new CultureConstraint(defaultCulture: ConfigurationManager.AppSettings["DefaultCulture"])
                          });

      _ = routes.MapRoute(name: "Default",
                          url: "{controller}/{action}/{id}",
                          defaults: new {
                            culture = ConfigurationManager.AppSettings["DefaultCulture"],
                            controller = "Home",
                            action = "Index",
                            id = UrlParameter.Optional
                          });
    }
  }
}
