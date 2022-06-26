using System;

using Apartments.BLL.Base.DomainModels;

namespace Apartments.BLL.DomainModels {
  public class OwnerDomainModel : BaseDomainModel<Int32> {
    public String Name { get; set; }
  }
}
