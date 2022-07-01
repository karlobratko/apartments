using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Apartments.BLL.DomainModels;

namespace Apartments.WebUI.Infrastructure.Auth.Attributes {
  public class AuthorizedAttribute : AuthorizeAttribute {
    protected override Boolean AuthorizeCore(HttpContextBase httpContext) => httpContext.Session["user"] is UserDomainModel user && user.IsAdmin;

    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
      if (filterContext.Result is null || filterContext.Result is HttpUnauthorizedResult) {
        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
        {
          { "controller", "Error" },
          { "action", "Forbidden" },
          { "culture", filterContext.RouteData.Values["culture"] }
        });
      }
    }
  }
}