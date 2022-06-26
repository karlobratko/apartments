using System;

using Apartments.BLL.Base.DomainModels;

namespace Apartments.BLL.DomainModels {
  public class TagTypeDomainModel : BaseDomainModel<Int32> {
    public String Name { get; set; }
    public String NameEng { get; set; }
  }
}
