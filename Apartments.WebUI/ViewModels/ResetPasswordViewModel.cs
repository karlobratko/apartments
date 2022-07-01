using System;
using System.ComponentModel.DataAnnotations;

namespace Apartments.WebUI.ViewModels {
  public class ResetPasswordViewModel {
    [System.Web.Mvc.HiddenInput(DisplayValue = false)]
    public Guid Guid { get; set; }

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