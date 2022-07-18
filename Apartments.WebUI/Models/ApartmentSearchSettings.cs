using System;
using System.Web.Helpers;

namespace Apartments.WebUI.Models {
  public class ApartmentSearchSettings {
    public Int32? TotalRooms { get; set; }
    public Int32? MaxAdults { get; set; }
    public Int32? MaxChildren { get; set; }
    public String CityName { get; set; }
    public String SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
  }
}