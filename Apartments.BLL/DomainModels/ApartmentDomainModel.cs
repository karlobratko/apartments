using System;

using Apartments.BLL.Base.DomainModels;

namespace Apartments.BLL.DomainModels {
  public class ApartmentDomainModel : BaseDomainModel<Int32> {
    public Int32 OwnerFK { get; set; }
    public Int32 StatusFK { get; set; }
    public String Name { get; set; }
    public String NameEng { get; set; }
    public Int32 CityFK { get; set; }
    public String Address { get; set; }
    public Decimal Price { get; set; }
    public Int32 MaxAdults { get; set; }
    public Int32 MaxChildren { get; set; }
    public Int32 TotalRooms { get; set; }
    public Int32 BeachDistance { get; set; }
  }
}
