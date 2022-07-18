using System;

using Apartments.DAL.Base.TableModels;

namespace Apartments.DAL.TableModels {
  public class MetadataTableModel : BaseTableModel<Int32> {
    public String Name { get; set; }
    public String OIB { get; set; }
    public Int32 CityFK { get; set; }
    public String Address { get; set; }
    public String Telephone { get; set; }
    public String Mobile { get; set; }
    public String Email { get; set; }
  }
}
