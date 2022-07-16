using System;

namespace Apartments.AdminUI.Projections {
  public class TagProjection {
    public Int32 Id { get; set; }
    public Guid Guid { get; set; }
    public String Name { get; set; }
    public String TypeName { get; set; }
    public Int32 ApartmentCount { get; set; }
  }
}
