using System;

using Apartments.BLL.Base.DomainModels;

namespace Apartments.BLL.DomainModels {
  public class TagApartmentDomainModel : BaseDomainModel<Int32> {
    public Int32 TagFK { get; set; }
    public Int32 ApartmentFK { get; set; }
  }
}
