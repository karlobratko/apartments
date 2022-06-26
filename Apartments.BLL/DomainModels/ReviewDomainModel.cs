using System;

using Apartments.BLL.Base.DomainModels;

namespace Apartments.BLL.DomainModels {
  public class ReviewDomainModel : BaseDomainModel<Int32> {
    public Int32 ApartmentFK { get; set; }
    public Int32 UserFK { get; set; }
    public String Details { get; set; }
    public Int32 Stars { get; set; }
  }
}
