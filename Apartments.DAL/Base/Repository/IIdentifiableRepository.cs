using System;

using Apartments.DAL.Base.TableModels;
using Apartments.DAL.Enums;

namespace Apartments.DAL.Base.Repository {
  public interface IIdentifiableRepository<TKey, TModel> : IReadWriteRepository<TModel>
    where TModel : class, IIdentifiable<TKey>
    where TKey : struct {
    TModel ReadByGuid(Guid guid);
    UpdateStatus Update(Guid guid, TModel model);
    DeleteStatus Delete(Guid guid);
  }
}
