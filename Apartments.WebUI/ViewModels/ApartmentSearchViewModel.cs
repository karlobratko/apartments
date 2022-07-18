using System.Collections.Generic;

using Apartments.BLL.DomainModels;
using Apartments.WebUI.Models;

namespace Apartments.WebUI.ViewModels {
  public class ApartmentSearchViewModel {
    public ApartmentSearchSettings SearchSettings { get; set; }
    public IEnumerable<CityDomainModel> Cities { get; set; }
  }
}