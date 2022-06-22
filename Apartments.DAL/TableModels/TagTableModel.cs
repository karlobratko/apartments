using System;

using Apartments.DAL.Base.TableModels;

namespace Apartments.DAL.TableModels {
  public class TagTableModel : BaseTableModel<Int32> {
    public String Name { get; set; }
    public String NameEng { get; set; }
    public Int32 TagType { get; set; }
  }
}
