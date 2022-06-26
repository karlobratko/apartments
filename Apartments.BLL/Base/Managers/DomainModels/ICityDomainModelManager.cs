using System;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface ICityDomainModelManager : IDomainModelManager<Int32, CityTableModel, CityDomainModel> {
  }
}
