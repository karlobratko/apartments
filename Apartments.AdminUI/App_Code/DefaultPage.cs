using System;

namespace Apartments.AdminUI {
  public class DefaultPage : System.Web.UI.Page {
    public DefaultPage() { }

    protected Int32 DDLThemeIndex {
      get =>
        Request.Cookies["theme"] != null &&
        Request.Cookies["theme"]["index"] != null
          ? Int32.Parse(Request.Cookies["theme"]["index"])
          : 0;

      set => Request.Cookies["theme"]["index"] = value.ToString();
    }

    protected Int32 DDLLanguageIndex {
      get =>
        Request.Cookies["lang"] != null &&
        Request.Cookies["lang"]["index"] != null
          ? Int32.Parse(Request.Cookies["lang"]["index"])
          : 0;

      set => Request.Cookies["lang"]["index"] = value.ToString();
    }

    protected override void OnPreInit(EventArgs e) {
      ChooseTheme();

      base.OnPreInit(e);
    }

    private void ChooseTheme() {
      if (Request.Cookies["theme"] != null &&
          Request.Cookies["theme"]["theme"] != null) {
        Theme = Request.Cookies["theme"]["theme"];
      }
    }
  }
}