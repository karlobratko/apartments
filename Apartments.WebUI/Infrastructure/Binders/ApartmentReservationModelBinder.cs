using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Web.Mvc;

using Apartments.WebUI.Models;

namespace Apartments.WebUI.Infrastructure.Binders {
  public class ApartmentReservationModelBinder : IModelBinder {
    public Object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
      NameValueCollection form = controllerContext.HttpContext.Request.Form;

      var model = new ApartmentReservationModel {
        ApartmentFK = Int32.Parse(form["ApartmentFK"]),
        FName = form["FName"],
        LName = form["LName"],
        Email = form["Email"],
        PhoneNumber = form["PhoneNumber"],
        Address = form["Address"],
        Adults = Int32.Parse(form["Adults"]),
        Children = Int32.Parse(form["Children"]),
        DateFrom = DateTime.Parse(form["DateFrom"], CultureInfo.CurrentCulture),
        DateTo = DateTime.Parse(form["DateTo"], CultureInfo.CurrentCulture),
      };

      return model;
    }
  }
}