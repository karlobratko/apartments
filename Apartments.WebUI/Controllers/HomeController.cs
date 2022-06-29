using System.Collections.Generic;
using System.Web.Mvc;

using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;

namespace Apartments.WebUI.Controllers {
  public class HomeController : Controller {
    private readonly IApartmentDomainModelManager _apartmentManager;

    public HomeController(IApartmentDomainModelManager apartmentManager) => _apartmentManager = apartmentManager;

    [HttpGet]
    [LocalizedRoute(template: "~/home")]
    public ActionResult Index() {

      IEnumerable<ApartmentDomainModel> enumerable = _apartmentManager.GetAllIfAvailable();
      return View(viewName: nameof(HomeController.Index),
                  model: enumerable);
    }
  }
}