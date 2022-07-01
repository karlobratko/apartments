using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

using Apartments.BLL.Extensions;

namespace Apartments.WebUI.Controllers {
  public class ErrorController : Controller {
    [ChildActionOnly]
    public ViewResult Error() {
      ConfigureCulture();

      return View(nameof(ErrorController.Error));
    }

    [HttpGet]
    [LocalizedRoute(template: "~/bad-request")]
    public ViewResult BadRequest() {
      Response.StatusCode = 400;
      return Error();
    }

    [HttpGet]
    [LocalizedRoute(template: "~/unauthorized")]
    public ViewResult Unauthorized() {
      Response.StatusCode = 401;
      return Error();
    }

    [HttpGet]
    [LocalizedRoute(template: "~/forbidden")]
    public ViewResult Forbidden() {
      Response.StatusCode = 403;
      return Error();
    }

    [HttpGet]
    [LocalizedRoute(template: "~/not-found")]
    public ViewResult NotFound() {
      Response.StatusCode = 404;
      return Error();
    }

    [HttpGet]
    [LocalizedRoute(template: "~/internal-server-error")]
    public ViewResult InternalServerError() {
      Response.StatusCode = 500;
      return Error();
    }

    private void ConfigureCulture() {
      String culture = Request.GetCulture();

      Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
      ViewBag.Culture = culture;
    }
  }
}