using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Apartments.WebUI.App_Start;
using Apartments.WebUI.Infrastructure.Routing;

using WorkingExample;

namespace Apartments.WebUI {
  public class MvcApplication : HttpApplication {
    protected void Application_Start() {
      RouteTable.Routes.MapLocalizedMvcAttributeRoutes();

      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
  }
}
