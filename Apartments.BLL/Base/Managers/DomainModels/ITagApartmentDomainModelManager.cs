using System;
using System.Collections.Generic;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface ITagApartmentDomainModelManager : IDomainModelManager<Int32, TagApartmentTableModel, TagApartmentDomainModel> {
    IEnumerable<TagApartmentDomainModel> GetByApartment(ApartmentDomainModel model);
  }
}
