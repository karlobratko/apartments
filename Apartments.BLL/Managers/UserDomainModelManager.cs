using System;
using System.Configuration;
using System.Globalization;
using System.Net.Mail;
using System.Web;

using Apartments.BLL.Base.Helpers;
using Apartments.BLL.Base.Managers;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.BLL.Extensions;
using Apartments.BLL.Helpers;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.Enums;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class UserDomainModelManager : BaseDomainModelManager<Int32, UserTableModel, UserDomainModel>,
                                        IUserDomainModelManager {

    #region Constructors

    public UserDomainModelManager(IUserTableModelRepository repository) : base(repository) {
    }

    #endregion

    #region Private Methods

    private void SendRegisterEmail(UserDomainModel model) {
      String link = GenerateRedirectionLink(translatedUrlName: "confirm-registration", guid: model.Guid);

      IEmailSender emailSender = new EmailSender(to: new MailAddress(model.Email, $"{model.FName} {model.LName}"));
      emailSender.SendEmail(subject: Resources.Global.Apartments.ResourceManager.GetString(name: "register-email-subject"),
                            body: String.Format(format: Resources.Global.Apartments.ResourceManager.GetString(name: "register-email-body"),
                                                model.FName,
                                                model.LName,
                                                link,
                                                link));
    }

    private void SendResetPasswordEmail(UserDomainModel model) {
      String link = GenerateRedirectionLink(translatedUrlName: "reset-password", guid: model.Guid);

      IEmailSender emailSender = new EmailSender(to: new MailAddress(model.Email, $"{model.FName} {model.LName}"));
      emailSender.SendEmail(subject: Resources.Global.Apartments.ResourceManager.GetString(name: "reset-password-email-subject"),
                            body: String.Format(format: Resources.Global.Apartments.ResourceManager.GetString(name: "reset-password-email-body"),
                                                model.FName,
                                                model.LName,
                                                link,
                                                link));
    }

    private static String GenerateRedirectionLink(String translatedUrlName, Guid guid) {
      String culture = HttpContext.Current.Request.GetCulture();
      String part = Resources.Global.TranslatedUrls.ResourceManager.GetString(name: translatedUrlName,
                                                                              culture: new CultureInfo(culture));

      String cultureUrl = culture == ConfigurationManager.AppSettings["DefaultCulture"] ? "" : $"/{culture}";
      return HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, $"{cultureUrl}/{part}/{guid}");
    }

    #endregion

    #region Public Methods

    #region Login

    public UserDomainModel Login(UserDomainModel model) {
      UserTableModel tableModel = (Repository as IUserTableModelRepository).Login(model: ToTableModel(model),
                                                                                  password: model.Password);
      return !(tableModel is null)
        ? ToDomainModel(model: tableModel)
        : null;
    }

    #endregion

    #region Registration

    public UserDomainModel BeginRegistration(UserDomainModel model) {
      UserTableModel tableModel = (Repository as IUserTableModelRepository).Register(model: ToTableModel(model),
                                                                                     password: model.Password,
                                                                                     registerStatus: out RegisterStatus registerStatus);

      switch (registerStatus) {
        case RegisterStatus.Failure:
        case RegisterStatus.UniquenessViolated:
        case RegisterStatus.AlreadyDeleted:
          return null;
        case RegisterStatus.Success:
          UserDomainModel registeredUserModel = ToDomainModel(tableModel);
          SendRegisterEmail(registeredUserModel);
          return registeredUserModel;
        default:
          throw new InvalidOperationException();
      }
    }

    public UserDomainModel BeginRegistration(UserDomainModel model, Int32 createdBy) {
      UserTableModel tableModel = (Repository as IUserTableModelRepository).Register(model: ToTableModel(model),
                                                                                     password: model.Password,
                                                                                     createdBy: createdBy,
                                                                                     registerStatus: out RegisterStatus registerStatus);

      switch (registerStatus) {
        case RegisterStatus.Failure:
        case RegisterStatus.UniquenessViolated:
        case RegisterStatus.AlreadyDeleted:
          return null;
        case RegisterStatus.Success:
          return ToDomainModel(tableModel);
        default:
          throw new InvalidOperationException();
      }
    }

    public RegistrationStatus CheckRegistrationStatus(Guid guid)
      => (Repository as IUserTableModelRepository).CheckRegistrationStatus(guid);

    public UserDomainModel ConfirmRegistration(Guid guid) {
      UserTableModel tableModel = (Repository as IUserTableModelRepository).ConfirmRegistration(guid: guid,
                                                                                                operationStatus: out OperationStatus operationStatus);

      switch (operationStatus) {
        case OperationStatus.Failure:
          return null;
        case OperationStatus.Success:
          return ToDomainModel(model: tableModel);
        default:
          throw new InvalidOperationException();
      }
    }

    public UserDomainModel ConfirmRegistration(Guid guid, Int32 updatedBy) {
      UserTableModel tableModel = (Repository as IUserTableModelRepository).ConfirmRegistration(guid: guid,
                                                                                                updatedBy: updatedBy,
                                                                                                operationStatus: out OperationStatus operationStatus);

      switch (operationStatus) {
        case OperationStatus.Failure:
          return null;
        case OperationStatus.Success:
          return ToDomainModel(model: tableModel);
        default:
          throw new InvalidOperationException();
      }
    }

    #endregion

    #region Reset Password

    public UserDomainModel GetByEmail(String email) {
      UserTableModel tableModel = (Repository as IUserTableModelRepository).ReadByEmail(email: email);
      return !(tableModel is null)
        ? ToDomainModel(tableModel)
        : null;
    }

    public UserDomainModel RequestResetPassword(String email) {
      UserTableModel tableModel = (Repository as IUserTableModelRepository).RequestResetPassword(email: email,
                                                                                                 requestResetPasswordStatus: out RequestResetPasswordStatus requestResetPasswordStatus);

      switch (requestResetPasswordStatus) {
        case RequestResetPasswordStatus.Failure:
        case RequestResetPasswordStatus.NotExists:
          return null;
        case RequestResetPasswordStatus.Success:
          UserDomainModel updatedModel = ToDomainModel(tableModel);
          SendResetPasswordEmail(model: updatedModel);
          return updatedModel;
        default:
          throw new InvalidOperationException();
      }
    }
    public UserDomainModel RequestResetPassword(String email, Int32 updatedBy) {
      UserTableModel tableModel = (Repository as IUserTableModelRepository).RequestResetPassword(email: email,
                                                                                                 updatedBy: updatedBy,
                                                                                                 requestResetPasswordStatus: out RequestResetPasswordStatus requestResetPasswordStatus);

      switch (requestResetPasswordStatus) {
        case RequestResetPasswordStatus.Failure:
        case RequestResetPasswordStatus.NotExists:
          return null;
        case RequestResetPasswordStatus.Success:
          return ToDomainModel(tableModel);
        default:
          throw new InvalidOperationException();
      }
    }

    public ResetPasswordStatus CheckResetPasswordStatus(Guid guid)
      => (Repository as IUserTableModelRepository).CheckResetPasswordStatus(guid: guid);

    public UserDomainModel ResetPassword(UserDomainModel model) {
      UserTableModel tableModel = (Repository as IUserTableModelRepository).ResetPassword(model: ToTableModel(model: model),
                                                                                          password: model.Password,
                                                                                          operationStatus: out OperationStatus operationStatus);

      switch (operationStatus) {
        case OperationStatus.Failure:
          return null;
        case OperationStatus.Success:
          return ToDomainModel(model: tableModel);
        default:
          throw new InvalidOperationException();
      }
    }

    public UserDomainModel ResetPassword(UserDomainModel model, Int32 updatedBy) {
      UserTableModel tableModel = (Repository as IUserTableModelRepository).ResetPassword(model: ToTableModel(model: model),
                                                                                          password: model.Password,
                                                                                          updatedBy: updatedBy,
                                                                                          operationStatus: out OperationStatus operationStatus);

      switch (operationStatus) {
        case OperationStatus.Failure:
          return null;
        case OperationStatus.Success:
          return ToDomainModel(model: tableModel);
        default:
          throw new InvalidOperationException();
      }
    }

    #endregion

    #region Profile

    public UserDomainModel EditProfile(UserDomainModel model) {
      UserTableModel tableModel = (Repository as IUserTableModelRepository).UpdateProfile(model: ToTableModel(model: model),
                                                                                          operationStatus: out OperationStatus operationStatus);

      switch (operationStatus) {
        case OperationStatus.Failure:
          return null;
        case OperationStatus.Success:
          return ToDomainModel(model: tableModel);
        default:
          throw new InvalidOperationException();
      }
    }

    public UserDomainModel EditProfile(UserDomainModel model, Int32 updatedBy) {
      UserTableModel tableModel = (Repository as IUserTableModelRepository).UpdateProfile(model: ToTableModel(model: model),
                                                                                          updatedBy: updatedBy,
                                                                                          operationStatus: out OperationStatus operationStatus);

      switch (operationStatus) {
        case OperationStatus.Failure:
          return null;
        case OperationStatus.Success:
          return ToDomainModel(model: tableModel);
        default:
          throw new InvalidOperationException();
      }
    }

    #endregion

    #endregion

  }
}
