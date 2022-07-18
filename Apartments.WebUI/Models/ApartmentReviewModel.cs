using System;

namespace Apartments.WebUI.Models {
  public class ApartmentReviewModel {
    public Int32 UserFK { get; set; }
    public Int32 ApartmentFK { get; set; }
    public Int32 Stars { get; set; }
    public String Details { get; set; }
  }
}