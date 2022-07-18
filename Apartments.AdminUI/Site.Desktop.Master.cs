using System;

namespace Apartments.AdminUI {
  public partial class Site_Desktop : System.Web.UI.MasterPage {
    protected void Page_Load(Object sender, EventArgs e) {
      if (Session["user"] == null) {
        Response.Redirect("Default.aspx");
      }
    }

    protected void btnLogout_Click(Object sender, EventArgs e) {
      Session["user"] = null;
      Response.Redirect("Default.aspx");
    }
  }
}