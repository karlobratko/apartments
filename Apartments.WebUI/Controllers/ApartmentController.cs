using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.WebUI.Models;
using Apartments.WebUI.ViewModels;

namespace Apartments.WebUI.Controllers {
  public class ApartmentController : Controller {
    private readonly IApartmentDomainModelManager _apartmentManager;
    private readonly ICityDomainModelManager _cityManager;
    private readonly IOwnerDomainModelManager _ownerManager;
    private readonly IStatusDomainModelManager _statusManager;
    private readonly IPictureDomainModelManager _pictureManager;

    public ApartmentController(IApartmentDomainModelManager apartmentManager,
                               ICityDomainModelManager cityManager,
                               IOwnerDomainModelManager ownerManager,
                               IStatusDomainModelManager statusManager,
                               IPictureDomainModelManager pictureManager) {
      _apartmentManager = apartmentManager;
      _cityManager = cityManager;
      _ownerManager = ownerManager;
      _statusManager = statusManager;
      _pictureManager = pictureManager;
    }

    [HttpGet]
    [LocalizedRoute(template: "~/search")]
    public ViewResult Search(ApartmentSearchSettings searchSettings)
      => View(viewName: nameof(ApartmentController.Search));

    [HttpGet]
    public JsonResult GetFilteredJson(ApartmentSearchSettings searchSettings,
                                      Int32? TotalRooms,
                                      Int32? MaxAdults,
                                      Int32? MaxChildren,
                                      String CityName,
                                      String SortBy,
                                      SortDirection SortDirection = SortDirection.Ascending)
      => Json(data: GetFilteredData(searchSettings), behavior: JsonRequestBehavior.AllowGet);

    [HttpGet]
    [Route(template: "~/getapartments")]
    public PartialViewResult GetFiltered(ApartmentSearchSettings searchSettings)
      => PartialView(viewName: $"_GetApartments", model: GetFilteredData(searchSettings));

    private IEnumerable<ApartmentCardViewModel> GetFilteredData(ApartmentSearchSettings searchSettings) {
      String culture = RouteData.Values["culture"].ToString();

      IEnumerable<ApartmentCardViewModel> apartments =
        from apartment in _apartmentManager.GetAllIfAvailable()
        let city = _cityManager.GetByIdIfAvailable(apartment.CityFK)
        let owner = _ownerManager.GetByIdIfAvailable(apartment.OwnerFK)
        let status = _statusManager.GetByIdIfAvailable(apartment.StatusFK)
        let picture = _pictureManager.GetRepresentative(apartment)
        where searchSettings.TotalRooms is null || apartment.TotalRooms == searchSettings.TotalRooms
        where searchSettings.MaxAdults is null || apartment.MaxAdults == searchSettings.MaxAdults
        where searchSettings.MaxChildren is null || apartment.MaxChildren == searchSettings.MaxChildren
        where city.Name.ToLower().Contains(value: searchSettings.CityName?.ToLower() ?? "")
        select new ApartmentCardViewModel {
          Id = apartment.Id,
          Name = culture == "en" ? apartment.NameEng : apartment.Name,
          Address = apartment.Address,
          ImagePath = picture?.Path,
          City = city.Name,
          Owner = owner.Name,
          Status = culture == "en" ? status.NameEng : status.Name,
        };

      apartments = apartments.SortBy(keySelector: model => typeof(ApartmentCardViewModel).GetProperty(name: searchSettings.SortBy ?? "Id").GetValue(model),
                                     sortDirection: searchSettings.SortDirection);

      return apartments;
    }
  }
}