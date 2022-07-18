using System;
using System.Web;
using System.Web.UI.WebControls;

namespace Apartments.AdminUI {
  public partial class Settings : DefaultPage {
    protected void Page_Load(Object sender, EventArgs e) {
      PreselectDDLThemeIndex();
      PreselectDDLLanguageIndex();
    }

    private void PreselectDDLLanguageIndex() {
      if (!IsPostBack)
        ddlLang.SelectedIndex = DDLLanguageIndex;
    }

    private void PreselectDDLThemeIndex() {
      if (!IsPostBack)
        ddlTheme.SelectedIndex = DDLThemeIndex;
    }

    protected void ddlTheme_SelectedIndexChanged(Object sender, EventArgs e) {
      DropDownList ddl = sender as DropDownList;

      HttpCookie cookieTheme = new HttpCookie("theme") { Expires = DateTime.Now.AddDays(10) };
      cookieTheme["theme"] = ddl.SelectedValue;
      cookieTheme["index"] = ddl.SelectedIndex.ToString();

      Response.Cookies.Add(cookieTheme);
      Response.Redirect(Request.Url.LocalPath);
    }

    protected void ddlLang_SelectedIndexChanged(Object sender, EventArgs e) {
      DropDownList ddl = sender as DropDownList;

      HttpCookie cookieLang = new HttpCookie("lang") { Expires = DateTime.Now.AddDays(10) };
      cookieLang["lang"] = ddl.SelectedValue;
      cookieLang["index"] = ddl.SelectedIndex.ToString();

      Response.Cookies.Add(cookieLang);
      Response.Redirect(Request.Url.LocalPath);
    }
  }
}