using System;

using Apartments.DAL.Base.TableModels;

namespace Apartments.DAL.TableModels {
  public class CityTableModel : BaseTableModel<Int32> {
    public String Name { get; set; }
  }
}
