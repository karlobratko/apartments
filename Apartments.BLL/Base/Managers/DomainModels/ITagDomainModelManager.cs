using System;
using System.Collections.Generic;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface ITagDomainModelManager : IDomainModelManager<Int32, TagTableModel, TagDomainModel> {
    IEnumerable<TagDomainModel> GetUnassigned(ApartmentDomainModel model);
    IEnumerable<TagDomainModel> GetByApartment(ApartmentDomainModel model);
  }
}
