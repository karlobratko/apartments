using System;

using Apartments.DAL.Base.TableModels;

namespace Apartments.DAL.TableModels {
  public class PictureTableModel : BaseTableModel<Int32> {
    public Int32 ApartmentFK { get; set; }
    public String Title { get; set; }
    public String Path { get; set; }
    public Boolean IsRepresentative { get; set; }
  }
}