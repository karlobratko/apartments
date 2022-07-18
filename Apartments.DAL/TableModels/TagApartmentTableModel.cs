using System;

using Apartments.DAL.Base.TableModels;

namespace Apartments.DAL.TableModels {
  public class TagApartmentTableModel : BaseTableModel<Int32> {
    public Int32 TagFK { get; set; }
    public Int32 ApartmentFK { get; set; }
  }
}
