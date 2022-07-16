using System;

using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;

namespace Apartments.AdminUI {
  public partial class Default : System.Web.UI.Page {
    protected void Page_Load(Object sender, EventArgs e) {

    }

    protected void LoginUser(Object sender, EventArgs e) {
      UserDomainModel user = ((IUserDomainModelManager)Application["Users"]).Login(new UserDomainModel {
        Email = txtEmail.Text.Trim(),
        Password = txtPassword.Text.Trim()
      });
      if (user == null) {
        return;
      }

      Session["user"] = user;
      Response.Redirect("Apartments.aspx");
    }
  }
}