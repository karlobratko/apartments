﻿using System;
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
      }

      String[] keys = controllerContext.HttpContext.Request.QueryString.AllKeys;
      foreach (String key in keys) {
        apartmentSearchSettings.GetType()
                               .GetProperty(name: key)
                               .SetValue(apartmentSearchSettings, bindingContext.ValueProvider.GetValue(key) ?? default);
      }

      return apartmentSearchSettings;
    }
  }
}