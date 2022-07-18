using System;

namespace Apartments.AdminUI.Projections {
  public class ApartmentProjection {
    public Guid Guid { get; set; }
    public Int32 Id { get; set; }
    public Int32 OwnerFK { get; set; }
    public String Owner { get; set; }
    public Int32 StatusFK { get; set; }
    public Int32 CityFK { get; set; }
    public String City { get; set; }
    public String Address { get; set; }
    public String Name { get; set; }
    public Decimal Price { get; set; }
    public Int32 MaxAdults { get; set; }
    public Int32 MaxChildren { get; set; }
    public Int32 TotalRooms { get; set; }
    public Int32 BeachDistance { get; set; }
    public Int32 PicturesCount { get; set; }
  }
}
