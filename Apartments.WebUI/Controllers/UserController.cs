using System;
using System.Web.Mvc;

using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.WebUI.Infrastructure.Auth.Attributes;
using Apartments.WebUI.Messages;
using Apartments.WebUI.ViewModels;

namespace Apartments.WebUI.Controllers {
  public class UserController : BaseController {
    private readonly IUserDomainModelManager _userManager;

    public UserController(IUserDomainModelManager userManager) => _userManager = userManager;

    [HttpGet]
    [LocalizedRoute(template: "~/profile")]
    [Authenticated]
    public ViewResult Details()
      => View(viewName: nameof(UserController.Details),
              model: LoggedInUser);

    [HttpGet]
    [LocalizedRoute(template: "~/edit-profile")]
    [Authenticated]
    public ViewResult Edit()
      => View(viewName: nameof(UserController.Edit),
              model: new UserEditViewModel {
                FName = LoggedInUser.FName,
                LName = LoggedInUser.LName,
                PhoneNumber = LoggedInUser.PhoneNumber,
                Address = LoggedInUser.Address
              });

    [HttpPost]
    [LocalizedRoute(template: "~/edit-profile")]
    [Authenticated]
    public ActionResult Edit(UserEditViewModel model) {
      if (!ModelState.IsValid)
        return View(viewName: nameof(UserController.Edit), model: model);

      UserDomainModel updatedUser = _userManager.EditProfile(model: new UserDomainModel {
        Guid = LoggedInUser.Guid,
        FName = model.FName,
        LName = model.LName,
        PhoneNumber = model.PhoneNumber,
        Address = model.Address
      });
      if (updatedUser is null) {
        Message = new WarningMessage(message: Resources.Global.Apartments.ResourceManager.GetString(name: "edit-profile-failed"));
        return View(viewName: nameof(UserController.Edit), model: model);
      }

      LoggedInUser = updatedUser;
      Message = new InfoMessage(message: Resources.Global.Apartments.ResourceManager.GetString(name: "edit-profile-success"));
      return RedirectToAction(actionName: nameof(UserController.Details));
    }

    [HttpGet]
    [LocalizedRoute(template: "~/delete-profile")]
    [Authenticated]
    public RedirectToRouteResult Delete() {
      Int32 deletedCount = _userManager.Remove(LoggedInUser);
      if (deletedCount == 0) {
        Message = new WarningMessage(message: Resources.Global.Apartments.ResourceManager.GetString(name: "delete-profile-failed"));
        return RedirectToAction(actionName: nameof(UserController.Details));
      }

      LoggedInUser = null;
      Message = new InfoMessage(message: Resources.Global.Apartments.ResourceManager.GetString(name: "delete-profile-success"));
      return RedirectToAction(actionName: "Index", controllerName: "Home");
    }
  }
}