using System;

using Apartments.DAL.Base.TableModels;

namespace Apartments.BLL.Base.DomainModels {
  public interface IDomainModel<TKey> : IIdentifiable<TKey>
    where TKey : struct {
    Boolean IsAvailable { get; }
  }
}
