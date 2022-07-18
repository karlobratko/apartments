using System;
using System.Web.Mvc;

using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Enums;
using Apartments.WebUI.Infrastructure.Auth.Attributes;
using Apartments.WebUI.Messages;
using Apartments.WebUI.Messages.Base;
using Apartments.WebUI.ViewModels;

namespace Apartments.WebUI.Controllers {
  public class AccountController : BaseController {
    private readonly IUserDomainModelManager _userManager;

    public AccountController(IUserDomainModelManager userManager) => _userManager = userManager;

    [HttpGet]
    [LocalizedRoute(template: "~/login")]
    public ActionResult Login()
      => !(LoggedInUser is null)
        ? new HttpStatusCodeResult(400)
        : (ActionResult)View(viewName: nameof(AccountController.Login));

    [HttpPost]
    [LocalizedRoute(template: "~/login")]
    public ActionResult Login(LoginViewModel model) {
      if (!(LoggedInUser is null))
        return new HttpStatusCodeResult(400);

      if (!ModelState.IsValid)
        return View(viewName: nameof(AccountController.Login), model: model);

      UserDomainModel loggedInUser =
        _userManager.Login(model: new UserDomainModel {
          Username = model.Username,
          Password = model.Password,
        });
      if (loggedInUser is null) {
        Message = new WarningMessage(message:  Resources.Global.Apartments.ResourceManager.GetString("login-failed"));
        return View(viewName: nameof(AccountController.Login), model: model);
      }

      LoggedInUser = loggedInUser;

      Message = new InfoMessage(message: Resources.Global.Apartments.ResourceManager.GetString("login-success"));
      return RedirectToAction(actionName: "Index", controllerName: "Home");
    }

    [HttpGet]
    [Authenticated]
    [LocalizedRoute(template: "~/logout")]
    public ActionResult Logout() {
      LoggedInUser = null;

      Message = new InfoMessage(message: Resources.Global.Apartments.ResourceManager.GetString("logout-success"));
      return RedirectToAction(actionName: "Index", controllerName: "Home");
    }

    [HttpGet]
    [LocalizedRoute(template: "~/register")]
    public ActionResult Register()
      => !(LoggedInUser is null)
        ? new HttpStatusCodeResult(400)
        : (ActionResult)View(viewName: nameof(AccountController.Register));

    [HttpPost]
    [LocalizedRoute(template: "~/register")]
    public ActionResult Register(RegisterViewModel model) {
      if (!(LoggedInUser is null))
        return new HttpStatusCodeResult(400);

      if (!ModelState.IsValid)
        return View(viewName: nameof(AccountController.Register), model: model);

      UserDomainModel registeredUser =
        _userManager.BeginRegistration(new UserDomainModel {
          FName = model.FName,
          LName = model.LName,
          Email = model.Email,
          Username = model.Username,
          Password = model.Password,
          IsAdmin = false
        });
      if (registeredUser is null) {
        Message = new WarningMessage(message:  Resources.Global.Apartments.ResourceManager.GetString("register-failed"));
        return View(viewName: nameof(AccountController.Register), model: model);
      }

      Message = new InfoMessage(message:  Resources.Global.Apartments.ResourceManager.GetString("register-success"));
      return RedirectToAction(actionName: nameof(AccountController.Login));
    }

    [HttpGet]
    [LocalizedRoute(template: "~/confirm-registration/{id}")]
    public ActionResult ConfirmRegistration(String id) {
      if (id is null || !Guid.TryParse(id, out Guid guid))
        return new HttpStatusCodeResult(404);

      RegistrationStatus registrationStatus = _userManager.CheckRegistrationStatus(guid);
      switch (registrationStatus) {
        case RegistrationStatus.Valid:
          Message = new InfoMessage(message: Resources.Global.Apartments.ResourceManager.GetString($"confirm-registration-{registrationStatus.ToString().ToLower()}"));
          _ = _userManager.ConfirmRegistration(guid: guid);
          return RedirectToAction(actionName: nameof(AccountController.Login));
        case RegistrationStatus.NotExists:
        case RegistrationStatus.AlreadyRegistered:
        case RegistrationStatus.Timeout:
          return new HttpStatusCodeResult(404);
        default:
          throw new InvalidOperationException();
      }
    }

    [HttpPost]
    [LocalizedRoute(template: "~/request-reset-password")]
    public RedirectToRouteResult RequestResetPassword(String email) {
      if (String.IsNullOrEmpty(email)) {
        Message = new WarningMessage(message: Resources.Global.Apartments.ResourceManager.GetString(name: "request-reset-password-email-invalid"));
        return RedirectToAction(actionName: nameof(AccountController.Login));
      }

      UserDomainModel model = _userManager.RequestResetPassword(email: email);

      Message = model is null
        ? new WarningMessage(message: Resources.Global.Apartments.ResourceManager.GetString(name: "request-reset-password-failed"))
        : (IMessage)new InfoMessage(message: Resources.Global.Apartments.ResourceManager.GetString(name: "request-reset-password-success"));
      return RedirectToAction(actionName: nameof(AccountController.Login));
    }

    [HttpGet]
    [LocalizedRoute(template: "~/reset-password/{id}")]
    public ActionResult ResetPassword(String id) {
      if (id is null || !Guid.TryParse(id, out Guid guid))
        return new HttpStatusCodeResult(404);

      ResetPasswordStatus resetPasswordStatus = _userManager.CheckResetPasswordStatus(guid);
      switch (resetPasswordStatus) {
        case ResetPasswordStatus.Valid:
          return View(viewName: nameof(AccountController.ResetPassword),
                      model: new ResetPasswordViewModel {
                        Guid = guid
                      });
        case ResetPasswordStatus.NotExists:
        case ResetPasswordStatus.AlreadyReset:
        case ResetPasswordStatus.Timeout:
          return new HttpStatusCodeResult(404);
        default:
          throw new InvalidOperationException();
      }
    }

    [HttpPost]
    [LocalizedRoute(template: "~/reset-password")]
    public ActionResult ResetPassword(ResetPasswordViewModel model) {
      if (!ModelState.IsValid)
        return View(viewName: nameof(AccountController.Register), model: model);

      UserDomainModel userDomainModel = _userManager.ResetPassword(new UserDomainModel {
        Guid = model.Guid,
        Password = model.Password
      });

      if (userDomainModel is null) {
        Message = new WarningMessage(message: Resources.Global.Apartments.ResourceManager.GetString(name: "reset-password-failed"));
        return View(viewName: nameof(AccountController.Register), model: model);
      }

      Message = new InfoMessage(message: Resources.Global.Apartments.ResourceManager.GetString(name: "reset-password-success"));
      return RedirectToAction(actionName: nameof(AccountController.Login));
    }
  }
}