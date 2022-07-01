using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.Resources.Global;
using Apartments.WebUI.Models;

namespace Apartments.WebUI.Controllers {
  public class ApartmentController : Controller {
    private readonly IApartmentDomainModelManager _apartmentManager;
    private readonly ICityDomainModelManager _cityManager;
    private readonly IOwnerDomainModelManager _ownerManager;
    private readonly IStatusDomainModelManager _statusManager;

    public ApartmentController(IApartmentDomainModelManager apartmentManager, 
                               ICityDomainModelManager cityManager,
                               IOwnerDomainModelManager ownerManager,
                               IStatusDomainModelManager statusManager) {
      _apartmentManager = apartmentManager;
      _cityManager = cityManager;
      _ownerManager = ownerManager;
      _statusManager = statusManager;
    }

    [HttpGet]
    [LocalizedRoute(template: "~/search")]
    public ActionResult Search(ApartmentSearchSettings searchSettings,
                               Int32? TotalRooms,
                               Int32? MaxAdults,
                               Int32? MaxChildren,
                               String CityName,
                               String SortBy = "Id",
                               SortDirection SortDirection = SortDirection.Ascending) {

      var apartments = from apartment in _apartmentManager.GetAll()
                       let city = _cityManager.GetByIdIfAvailable(apartment.CityFK)
                       let owner = _ownerManager.GetByIdIfAvailable(apartment.OwnerFK)
                       let status = _statusManager.GetByIdIfAvailable(apartment.StatusFK)
                       where TotalRooms is null || apartment.TotalRooms == searchSettings.TotalRooms
                       where MaxAdults is null || apartment.MaxAdults == searchSettings.MaxAdults
                       where MaxChildren is null || apartment.MaxChildren == searchSettings.MaxChildren
                       where city.Name.ToLower().Contains(value: CityName.ToLower())
                       select new {
                         Apartment = apartment,
                         City = city,
                         Owner = owner,
                         Status = status
                       };

      apartments = apartments.SortBy(keySelector: model => typeof(ApartmentDomainModel).GetProperty(name: SortBy).GetValue(model.Apartment),
                                     sortDirection: SortDirection);

      return View(viewName: nameof(ApartmentController.Search),
                  model: apartments);
    }
  }
}