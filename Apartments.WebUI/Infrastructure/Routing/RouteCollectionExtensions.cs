using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

using Apartments.WebUI.Infrastructure.Routing.Providers;

namespace Apartments.WebUI.Infrastructure.Routing {
  public static class RouteCollectionExtensions {
    public static void MapLocalizedMvcAttributeRoutes(this RouteCollection routes)
      => routes.MapMvcAttributeRoutes(new LocalizeDirectRouteProvider(urlPrefix: "{culture}/",
                                                                      defaultCulture: ConfigurationManager.AppSettings["DefaultCulture"],
                                                                      allCultures: ConfigurationManager.AppSettings["SupportedCultures"].Split(',')));
  }
}