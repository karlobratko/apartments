using System;

using Apartments.BLL.DomainModels;
using Apartments.DAL.Enums;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface IUserDomainModelManager : IDomainModelManager<Int32, UserTableModel, UserDomainModel> {

    #region Login

    UserDomainModel Login(UserDomainModel model);

    #endregion

    #region Registration

    UserDomainModel BeginRegistration(UserDomainModel model);
    UserDomainModel BeginRegistration(UserDomainModel model, Int32 createdBy);

    RegistrationStatus CheckRegistrationStatus(Guid guid);

    UserDomainModel ConfirmRegistration(Guid guid);
    UserDomainModel ConfirmRegistration(Guid guid, Int32 updatedBy);

    #endregion

    #region Reset Password

    UserDomainModel GetByEmail(String email);

    UserDomainModel RequestResetPassword(String email);
    UserDomainModel RequestResetPassword(String email, Int32 updatedBy);

    ResetPasswordStatus CheckResetPasswordStatus(Guid guid);

    UserDomainModel ResetPassword(UserDomainModel model);
    UserDomainModel ResetPassword(UserDomainModel model, Int32 updatedBy);

    #endregion

    #region Profile

    UserDomainModel EditProfile(UserDomainModel model);
    UserDomainModel EditProfile(UserDomainModel model, Int32 updatedBy);

    #endregion

  }
}
