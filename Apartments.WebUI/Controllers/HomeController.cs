using System.Web.Mvc;

namespace Apartments.WebUI.Controllers {
  public class HomeController : BaseController {
    [HttpGet]
    [LocalizedRoute(template: "~/home")]
    public ActionResult Index()
      => View(viewName: nameof(HomeController.Index));

    [HttpGet]
    [LocalizedRoute(template: "~/contact")]
    public ActionResult Contact()
      => View(viewName: nameof(HomeController.Contact));

    [HttpGet]
    [LocalizedRoute(template: "~/about")]
    public ActionResult About()
      => View(viewName: nameof(HomeController.About));
  }
}