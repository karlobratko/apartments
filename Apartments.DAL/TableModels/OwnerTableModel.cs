using System;

using Apartments.DAL.Base.TableModels;

namespace Apartments.DAL.TableModels {
  public class OwnerTableModel : BaseTableModel<Int32> {
    public String Name { get; set; }
  }
}
