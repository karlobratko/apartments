using System;
using System.ComponentModel.DataAnnotations;

namespace Apartments.WebUI.ViewModels {
  public class UserEditViewModel {
    [Display(Name = nameof(Resources.Global.ModelValidation.fname), ResourceType = typeof(Resources.Global.ModelValidation))]
    [Required(ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.fname_required), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [StringLength(maximumLength: 50, ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.fname_stringlength), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [DataType(DataType.Text)]
    public String FName { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.lname), ResourceType = typeof(Resources.Global.ModelValidation))]
    [Required(ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.lname_required), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [StringLength(maximumLength: 50, ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.lname_stringlength), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [DataType(DataType.Text)]
    public String LName { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.phone_number), ResourceType = typeof(Resources.Global.ModelValidation))]
    [StringLength(maximumLength: 20, ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.phone_number_stringlength), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [DataType(DataType.PhoneNumber)]
    public String PhoneNumber { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.address), ResourceType = typeof(Resources.Global.ModelValidation))]
    [StringLength(maximumLength: 200, ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.address_stringlength), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [DataType(DataType.Text)]
    public String Address { get; set; }
  }
}