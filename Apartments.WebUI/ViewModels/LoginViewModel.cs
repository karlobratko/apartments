using System;
using System.ComponentModel.DataAnnotations;

namespace Apartments.WebUI.ViewModels {
  public class LoginViewModel {
    [Display(Name = nameof(Resources.Global.ModelValidation.username), ResourceType = typeof(Resources.Global.ModelValidation))]
    [Required(ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.username_required), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [StringLength(maximumLength: 50, ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.username_stringlength), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [DataType(DataType.Text)]
    public String Username { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.password), ResourceType = typeof(Resources.Global.ModelValidation))]
    [Required(ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.password_required), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [StringLength(maximumLength: 512, MinimumLength = 3, ErrorMessageResourceName = nameof(Resources.Global.ModelValidation.password_stringlength), ErrorMessageResourceType = typeof(Resources.Global.ModelValidation))]
    [DataType(DataType.Password)]
    public String Password { get; set; }
  }
}