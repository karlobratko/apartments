using System;

using Apartments.BLL.Base.Managers;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
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
          return ToDomainModel(tableModel);
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
        case OperationStatus.FAILURE:
          return null;
        case OperationStatus.SUCCESS:
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
        case OperationStatus.FAILURE:
          return null;
        case OperationStatus.SUCCESS:
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
          return ToDomainModel(tableModel);
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
        case OperationStatus.FAILURE:
          return null;
        case OperationStatus.SUCCESS:
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
        case OperationStatus.FAILURE:
          return null;
        case OperationStatus.SUCCESS:
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
        case OperationStatus.FAILURE:
          return null;
        case OperationStatus.SUCCESS:
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
        case OperationStatus.FAILURE:
          return null;
        case OperationStatus.SUCCESS:
          return ToDomainModel(model: tableModel);
        default:
          throw new InvalidOperationException();
      }
    }

    #endregion

    #endregion

  }
}
