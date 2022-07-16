using System;
using System.Web;
using System.Web.Mvc;

using Apartments.BLL.DomainModels;
using Apartments.WebUI.Messages.Base;

namespace Apartments.WebUI.Controllers {
  public abstract class BaseController : Controller {
    public UserDomainModel LoggedInUser {
      get => Session["user"] as UserDomainModel;
      set => Session["user"] = value;
    }

    public IMessage Message {
      get => TempData["message"] as IMessage;
      set => TempData["message"] = value;
    }

    public String Language {
      get => Request.Cookies["language"].ToString();
      set => Request.Cookies.Add(new HttpCookie("language") { Value = value });
    }
  }
}