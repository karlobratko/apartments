using System;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface ITagApartmentDomainModelManager : IDomainModelManager<Int32, TagApartmentTableModel, TagApartmentDomainModel> {
  }
}
