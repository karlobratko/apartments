using System.Collections.Generic;

namespace Apartments.DAL.Base.Repository {
  public interface IReadOnlyRepository<TModel>
    where TModel : class {
    IEnumerable<TModel> ReadAll();
  }
}
