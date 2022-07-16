using System;

namespace Apartments.WebUI.ViewModels {
  public class ApartmentCardViewModel {
    public Int32 Id { get; set; }
    public String Name { get; set; }
    public String Address { get; set; }
    public Byte[] ImageData { get; set; }
    public String MimeType { get; set; }
    public String City { get; set; }
    public String Owner { get; set; }
    public String Status { get; set; }
    public String DetailsUrl { get; set; }
  }
}