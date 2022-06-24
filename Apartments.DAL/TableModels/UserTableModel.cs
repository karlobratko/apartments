using System;

using Apartments.DAL.Base.TableModels;

namespace Apartments.DAL.TableModels {
  public class UserTableModel : BaseTableModel<Int32> {
    public String FName { get; set; }
    public String LName { get; set; }
    public String Username { get; set; }
    public String Email { get; set; }
    public String PhoneNumber { get; set; }
    public String PasswordHash { get; set; }
    public String Address { get; set; }
    public Boolean IsAdmin { get; set; }
    public Boolean IsRegistered { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public Boolean CanResetPassword { get; set; }
    public DateTime? ResetPasswordStartDate { get; set; }
  }
}
