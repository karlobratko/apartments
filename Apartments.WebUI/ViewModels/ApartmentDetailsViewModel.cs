using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Apartments.BLL.DomainModels;

namespace Apartments.WebUI.ViewModels {
  public class ApartmentDetailsViewModel {
    public Int32 Id { get; set; }

    public String Name { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.address), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String Address { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.price), ResourceType = typeof(Resources.Global.ModelValidation))]
    [DataType(DataType.Currency)]
    public Decimal Price { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.max_adults), ResourceType = typeof(Resources.Global.ModelValidation))]
    public Int32 MaxAdults { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.max_children), ResourceType = typeof(Resources.Global.ModelValidation))]
    public Int32 MaxChildren { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.total_rooms), ResourceType = typeof(Resources.Global.ModelValidation))]
    public Int32 TotalRooms { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.beach_distance), ResourceType = typeof(Resources.Global.ModelValidation))]
    public Int32 BeachDistance { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.city), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String City { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.status), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String Status { get; set; }

    [Display(Name = nameof(Resources.Global.ModelValidation.owner), ResourceType = typeof(Resources.Global.ModelValidation))]
    public String Owner { get; set; }
    public PictureDomainModel RepresentativePicture { get; set; }
    public IEnumerable<PictureDomainModel> Pictures { get; set; }
    public IEnumerable<TagDomainModel> Tags { get; set; }
  }
}