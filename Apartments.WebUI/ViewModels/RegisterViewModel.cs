using System;
using System.ComponentModel.DataAnnotations;

namespace Apartments.WebUI.ViewModels {
  public class RegisterViewModel {
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

    [Display(Name = nameof(Resources.Global.ModelValidation.username), ResourceType = typeof(Resources.Global.ModelValidation))]
    [Required(ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.username_required), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [StringLength(maximumLength: 50, ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.username_stringlength), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [DataType(DataType.Text)]
    public String Username { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.email), ResourceType = typeof(Resources.Global.ModelValidation))]
    [Required(ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.email_required), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [StringLength(maximumLength: 256, ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.email_stringlength), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [DataType(DataType.EmailAddress)]
    public String Email { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.password), ResourceType = typeof(Resources.Global.ModelValidation))]
    [Required(ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.password_required), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [StringLength(maximumLength: 512, MinimumLength = 3, ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.password_stringlength), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [DataType(DataType.Password)]
    public String Password { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.confirm_password), ResourceType = typeof(Resources.Global.ModelValidation))]
    [Required(ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.confirm_password_required), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [StringLength(maximumLength: 512, MinimumLength = 3, ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.confirm_password_stringlength), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [Compare(otherProperty: nameof(Password), ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.confirm_password_compare), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [DataType(DataType.Password)]
    public String ConfirmPassword { get; set; }
  }
}