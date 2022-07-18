using System;

namespace Apartments.AdminUI.Projections {
  public class TagApartmentProjection {
    public Guid Guid { get; set; }
    public String Name { get; set; }
    public Int32 ApartmentFK { get; set; }
    public Int32 TagFK { get; set; }
  }
}
