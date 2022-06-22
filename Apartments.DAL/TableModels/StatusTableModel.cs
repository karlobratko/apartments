using System;

using Apartments.DAL.Base.TableModels;

namespace Apartments.DAL.TableModels {
  public class StatusTableModel : BaseTableModel<Int32> {
    public String Name { get; set; }
    public String NameEng { get; set; }
  }
}
