using System;
using System.Collections.Specialized;
using System.Web.Helpers;
using System.Web.Mvc;

using Apartments.WebUI.Models;

namespace Apartments.WebUI.Infrastructure.Binders {
  public class ApartmentSearchSettingsModelBinder : IModelBinder {
    private static readonly String SESSION_KEY = nameof(ApartmentSearchSettings);

    public Object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
      ApartmentSearchSettings apartmentSearchSettings = null;
      if (!(controllerContext.HttpContext.Session is null)) {
        apartmentSearchSettings = (ApartmentSearchSettings)controllerContext.HttpContext.Session[SESSION_KEY];
      }

      if (apartmentSearchSettings is null) {
        apartmentSearchSettings = new ApartmentSearchSettings();
        if (!(controllerContext.HttpContext.Session is null)) {
          controllerContext.HttpContext.Session[SESSION_KEY] = apartmentSearchSettings;
        }

        apartmentSearchSettings.SortBy = "Id";
      }
      else {
        Boolean isAjaxRequest = controllerContext.HttpContext.Request.IsAjaxRequest();
        NameValueCollection queryString = controllerContext.HttpContext.Request.QueryString;

        apartmentSearchSettings.TotalRooms =
          Int32.TryParse(queryString["totalRooms"], out Int32 totalRooms)
            ? totalRooms
            : isAjaxRequest
              ? null
              : apartmentSearchSettings.TotalRooms;

        apartmentSearchSettings.MaxAdults =
          Int32.TryParse(queryString["maxAdults"], out Int32 maxAdults)
            ? maxAdults
            : isAjaxRequest
              ? null
              : apartmentSearchSettings.MaxAdults;

        apartmentSearchSettings.MaxChildren =
          Int32.TryParse(queryString["maxChildren"], out Int32 maxChildren)
            ? maxChildren
            : isAjaxRequest
              ? null
              : apartmentSearchSettings.MaxChildren;

        apartmentSearchSettings.CityName =
          !(queryString["cityName"] is null)
            ? queryString["cityName"]
            : isAjaxRequest
              ? null
              : apartmentSearchSettings.CityName;

        apartmentSearchSettings.SortBy =
          !(queryString["sortBy"] is null)
            ? queryString["sortBy"]
            : isAjaxRequest
              ? null
              : apartmentSearchSettings.SortBy;

        apartmentSearchSettings.SortDirection =
          Enum.TryParse(queryString["sortDirection"], out SortDirection sortDirection)
            ? sortDirection
            : isAjaxRequest
              ? SortDirection.Ascending
              : apartmentSearchSettings.SortDirection;
      }

      return apartmentSearchSettings;
    }
  }
}