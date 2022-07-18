using System;

using Apartments.BLL.Base.DomainModels;

namespace Apartments.BLL.DomainModels {
  public class PictureDomainModel : BaseDomainModel<Int32> {
    public Int32 ApartmentFK { get; set; }
    public String Title { get; set; }
    public Byte[] Data { get; set; }
    public String MimeType { get; set; }
    public Boolean IsRepresentative { get; set; }
  }
}
