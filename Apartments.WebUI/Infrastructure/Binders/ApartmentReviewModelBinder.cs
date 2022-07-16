using System;
using System.Collections.Specialized;
using System.Web.Mvc;

using Apartments.WebUI.Models;

namespace Apartments.WebUI.Infrastructure.Binders {
  public class ApartmentReviewModelBinder : IModelBinder {
    public Object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
      NameValueCollection form = controllerContext.HttpContext.Request.Form;

      var model = new ApartmentReviewModel {
        UserFK = Int32.Parse(form["UserFK"]),
        ApartmentFK = Int32.Parse(form["ApartmentFK"]),
        Stars = Int32.Parse(form["Stars"]),
        Details = form["Details"]
      };

      return model;
    }
  }
}