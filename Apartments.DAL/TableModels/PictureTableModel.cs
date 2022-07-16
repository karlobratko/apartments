using System;

using Apartments.DAL.Base.TableModels;

namespace Apartments.DAL.TableModels {
  public class PictureTableModel : BaseTableModel<Int32> {
    public Int32 ApartmentFK { get; set; }
    public String Title { get; set; }
    public Byte[] Data { get; set; }
    public String MimeType { get; set; }
    public Boolean IsRepresentative { get; set; }
  }
}