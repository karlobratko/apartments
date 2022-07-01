using System;
using System.Configuration;
using System.Web;

namespace Apartments.BLL.Extensions {
  public static class HttpRequestExtensions {
    public static String GetCulture(this HttpRequestBase request) {
      String[] urlParts = request.RawUrl.Substring(startIndex: 1).Split('/');
      return urlParts.Length == 0 || urlParts[0].Length != 2
        ? ConfigurationManager.AppSettings["DefaultCulture"]
        : urlParts[0];
    }

    public static String GetCulture(this HttpRequest request) {
      String[] urlParts = request.RawUrl.Substring(startIndex: 1).Split('/');
      return urlParts.Length == 0 || urlParts[0].Length != 2
        ? ConfigurationManager.AppSettings["DefaultCulture"]
        : urlParts[0];
    }
  }
}
