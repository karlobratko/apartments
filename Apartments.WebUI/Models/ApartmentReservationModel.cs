using System;

namespace Apartments.WebUI.Models {
  public class ApartmentReservationModel {
    public Int32 ApartmentFK { get; set; }
    public String FName { get; set; }
    public String LName { get; set; }
    public String Email { get; set; }
    public String PhoneNumber { get; set; }
    public String Address { get; set; }
    public Int32 Adults { get; set; }
    public Int32 Children { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
  }
}