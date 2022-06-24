
using Apartments.DAL.Enums;

namespace Apartments.DAL.Base.Repository {
  public interface IReadWriteRepository<TModel> : IReadOnlyRepository<TModel>
    where TModel : class {
    TModel Create(TModel model, out CreateStatus createStatus);
    UpdateStatus Update(TModel model);
    DeleteStatus Delete(TModel model);
  }
}
