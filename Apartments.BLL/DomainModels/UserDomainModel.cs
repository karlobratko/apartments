using System;

using Apartments.BLL.Base.DomainModels;

namespace Apartments.BLL.DomainModels {
  public class UserDomainModel : BaseDomainModel<Int32> {
    public String FName { get; set; }
    public String LName { get; set; }
    public String Username { get; set; }
    public String Email { get; set; }
    public String PhoneNumber { get; set; }
    public String Address { get; set; }
    public Boolean IsAdmin { get; set; }

    public String Password { get; set; }
  }
}
