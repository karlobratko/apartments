using System;

using Apartments.BLL.Base.DomainModels;

namespace Apartments.BLL.DomainModels {
  public class TagDomainModel : BaseDomainModel<Int32> {
    public String Name { get; set; }
    public String NameEng { get; set; }
    public Int32 TagTypeFK { get; set; }
  }
}
