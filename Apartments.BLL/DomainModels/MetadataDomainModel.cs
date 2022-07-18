using System;
using System.ComponentModel.DataAnnotations;

using Apartments.BLL.Base.DomainModels;
namespace Apartments.BLL.DomainModels {
  public class MetadataDomainModel : BaseDomainModel<Int32> {
    public String Name { get; set; }

    public String OIB { get; set; }

    public CityDomainModel City { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.address), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String Address { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.telephone), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String Telephone { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.mobile), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String Mobile { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.email), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String Email { get; set; }
  }
}
