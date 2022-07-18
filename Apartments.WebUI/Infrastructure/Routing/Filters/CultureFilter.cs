using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

using Apartments.WebUI.Infrastructure.Routing.Attributes;

namespace WorkingExample.RouteLocalization {
  public class CultureFilter : IAuthorizationFilter {
    private readonly String _defaultCulture;

    public CultureFilter(String defaultCulture) => _defaultCulture = defaultCulture;

    public void OnAuthorization(AuthorizationContext filterContext) {
      IEnumerable<FilterAttribute> attributes = filterContext.ActionDescriptor.GetFilterAttributes(true);
      if (attributes.OfType<ForceCultureAttribute>().Any())
        return;

      RouteValueDictionary values = filterContext.RouteData.Values;

      String culture = (String)values["culture"] ?? _defaultCulture;

      var cultureInfo = new CultureInfo(culture);

      cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
      cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
      cultureInfo.NumberFormat.PercentDecimalSeparator = ".";
      cultureInfo.NumberFormat.NumberGroupSeparator = " ";
      cultureInfo.NumberFormat.CurrencyGroupSeparator = " ";

      Thread.CurrentThread.CurrentCulture = cultureInfo;
      Thread.CurrentThread.CurrentUICulture = cultureInfo;
    }
  }
}