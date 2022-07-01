using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Apartments.WebUI.Infrastructure.Routing.Attributes {
  public class ForceCultureAttribute : FilterAttribute, IAuthorizationFilter {
    public String Culture { get; set; }

    public void OnAuthorization(AuthorizationContext filterContext) {
      var culture = new CultureInfo(Culture);

      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
    }
  }
}