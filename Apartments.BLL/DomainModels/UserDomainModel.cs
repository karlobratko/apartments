using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Xml.Linq;

using Apartments.BLL.Base.DomainModels;
namespace Apartments.BLL.DomainModels {
public class UserDomainModel : BaseDomainModel<Int32> {
    [Display(Name = nameof(Resources.Global.ModelValidation.fname), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String FName { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.lname), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String LName { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.username), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String Username { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.email), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String Email { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.phone_number), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String PhoneNumber { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.address), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String Address { get; set; }
    public Boolean IsAdmin { get; set; }
    public String Password { get; set; }
  }
}
