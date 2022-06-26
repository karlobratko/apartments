using System;
using System.Collections.Generic;

using Apartments.BLL.Base.DomainModels;
using Apartments.DAL.Base.Repository;
using Apartments.DAL.Base.TableModels;

namespace Apartments.BLL.Base.Managers {
  public interface IDomainModelManager<TKey, TTableModel, TDomainModel>
    where TTableModel : class, ITableModel<TKey>
    where TDomainModel : class, IDomainModel<TKey>
    where TKey : struct {
    ITableModelRepository<TKey, TTableModel> Repository { get; }

    TDomainModel ToDomainModel(TTableModel model);
    TTableModel ToTableModel(TDomainModel model);

    TDomainModel Add(TDomainModel model);
    TDomainModel Add(TDomainModel model, TKey createdBy);

    Int32 Edit(TDomainModel model);
    Int32 Edit(Guid guid, TDomainModel model);
    Int32 Edit(TDomainModel model, TKey updatedBy);
    Int32 Edit(Guid guid, TDomainModel model, TKey updatedBy);

    Int32 Remove(TDomainModel model);
    Int32 Remove(Guid guid);
    Int32 Remove(TDomainModel model, TKey deletedBy);
    Int32 Remove(Guid guid, TKey deletedBy);

    TDomainModel GetByGuid(Guid guid);
    TDomainModel GetByGuidIfAvailable(Guid guid);

    IEnumerable<TDomainModel> GetAll();
    IEnumerable<TDomainModel> GetAllIfAvailable();
  }
}
