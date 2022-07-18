using System;
using System.Collections.Generic;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface IApartmentDomainModelManager : IDomainModelManager<Int32, ApartmentTableModel, ApartmentDomainModel> {
    IEnumerable<ApartmentDomainModel> GetByTag(TagDomainModel tag);
  }
}
