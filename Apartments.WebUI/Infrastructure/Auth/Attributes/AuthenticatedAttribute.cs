using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace Apartments.WebUI.Infrastructure.Auth.Attributes {
  public class AuthenticatedAttribute : FilterAttribute, IAuthenticationFilter {
    public void OnAuthentication(AuthenticationContext filterContext) {
      if (filterContext.HttpContext.Session["user"] is null) {
        filterContext.Result = new HttpUnauthorizedResult();
      }
    }

    public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext) {
      if (filterContext.Result is null || filterContext.Result is HttpUnauthorizedResult) {
        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
        {
          { "controller", "Error" },
          { "action", "Unauthorized" },
          { "culture", filterContext.RouteData.Values["culture"] }
        });
      }
    }
  }
}