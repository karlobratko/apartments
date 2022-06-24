using System;

using Apartments.DAL.Enums;
using Apartments.DAL.TableModels;

namespace Apartments.DAL.Base.Repository.TableModels {
  public interface IUserTableModelRepository : ITableModelRepository<Int32, UserTableModel> {
    #region Login

    UserTableModel Login(UserTableModel model, String password);
    UserTableModel Login(String username, String email, String password);

    #endregion

    #region Registration

    UserTableModel Register(UserTableModel model, String password, out RegisterStatus registerStatus);
    UserTableModel Register(String fName, String lName, String username, String email, String password, Boolean isAdmin, out RegisterStatus registerStatus);
    UserTableModel Register(String fName, String lName, String username, String email, String password, Boolean isAdmin, Int32? createdBy, out RegisterStatus registerStatus);

    RegistrationStatus CheckRegistrationStatus(UserTableModel model);
    RegistrationStatus CheckRegistrationStatus(Guid guid);

    UserTableModel ConfirmRegistration(UserTableModel model, out OperationStatus operationStatus);
    UserTableModel ConfirmRegistration(Guid guid, out OperationStatus operationStatus);
    UserTableModel ConfirmRegistration(Guid guid, Int32? updatedBy, out OperationStatus operationStatus);

    #endregion

    #region Reset Password

    UserTableModel ReadByEmail(UserTableModel model);
    UserTableModel ReadByEmail(String email);

    UserTableModel RequestResetPassword(UserTableModel model, out RequestResetPasswordStatus requestResetPasswordStatus);
    UserTableModel RequestResetPassword(String email, out RequestResetPasswordStatus requestResetPasswordStatus);
    UserTableModel RequestResetPassword(String email, Int32? updatedBy, out RequestResetPasswordStatus requestResetPasswordStatus);

    ResetPasswordStatus CheckResetPasswordStatus(UserTableModel model);
    ResetPasswordStatus CheckResetPasswordStatus(Guid guid);

    UserTableModel ResetPassword(UserTableModel model, String password, out OperationStatus operationStatus);
    UserTableModel ResetPassword(Guid guid, String password, out OperationStatus operationStatus);
    UserTableModel ResetPassword(Guid guid, String password, Int32? updatedBy, out OperationStatus operationStatus);

    #endregion

    #region Profile

    UserTableModel UpdateProfile(UserTableModel model, out OperationStatus operationStatus);
    UserTableModel UpdateProfile(Guid guid, String fName, String lName, String phoneNumber, String address, out OperationStatus operationStatus);
    UserTableModel UpdateProfile(Guid guid, String fName, String lName, String phoneNumber, String address, Int32? updatedBy, out OperationStatus operationStatus);

    #endregion
  }
}
