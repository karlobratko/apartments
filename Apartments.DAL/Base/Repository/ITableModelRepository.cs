using System;
using System.Collections.Generic;

using Apartments.DAL.Base.TableModels;
using Apartments.DAL.Enums;

namespace Apartments.DAL.Base.Repository {
  public interface ITableModelRepository<TKey, TModel> : IIdentifiableRepository<TKey, TModel>
    where TModel : class, ITableModel<TKey>
    where TKey : struct {
    TModel Create(TModel model, TKey? createdBy, out CreateStatus createStatus);
    IEnumerable<TModel> ReadAllAvailable();
    TModel ReadByIdAvailable(TKey id);
    UpdateStatus Update(Guid guid, TModel model, TKey? updatedBy);
    DeleteStatus Delete(Guid guid, TKey? deletedBy);
  }
}
