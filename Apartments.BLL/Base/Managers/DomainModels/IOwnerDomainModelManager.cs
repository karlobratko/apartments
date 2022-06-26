using System;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface IOwnerDomainModelManager : IDomainModelManager<Int32, OwnerTableModel, OwnerDomainModel> {
  }
}
