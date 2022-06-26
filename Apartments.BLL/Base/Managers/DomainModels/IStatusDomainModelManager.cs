using System;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface IStatusDomainModelManager : IDomainModelManager<Int32, StatusTableModel, StatusDomainModel> {
  }
}
