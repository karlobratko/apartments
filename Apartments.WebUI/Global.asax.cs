using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.WebUI.App_Start;
using Apartments.WebUI.Infrastructure.Binders;
using Apartments.WebUI.Infrastructure.Routing;
using Apartments.WebUI.Infrastructure.State;
using Apartments.WebUI.Models;

using WorkingExample;

namespace Apartments.WebUI {
  public class MvcApplication : HttpApplication {
    protected void Application_Start() {
      RouteTable.Routes.MapLocalizedMvcAttributeRoutes();

      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(filters: GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(routes: RouteTable.Routes);
      BundleConfig.RegisterBundles(bundles: BundleTable.Bundles);

      ModelBinders.Binders.Add(key: typeof(ApartmentSearchSettings), value: new ApartmentSearchSettingsModelBinder());
      ModelBinders.Binders.Add(key: typeof(ApartmentReservationModel), value: new ApartmentReservationModelBinder());
      ModelBinders.Binders.Add(key: typeof(ApartmentReviewModel), value: new ApartmentReviewModelBinder());

      Application.SetApplicationState(objectName: "metadata", 
                                      objectValue: DependencyResolver.Current.GetService<IMetadataDomainModelManager>().GetMetadata());
    }

    //protected void Application_Error(Object sender, EventArgs e) {
    //}
  }
}
