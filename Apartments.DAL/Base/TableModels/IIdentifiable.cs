using System;

namespace Apartments.DAL.Base.TableModels {
  public interface IIdentifiable<TKey>
    where TKey : struct {
    TKey Id { get; set; }
    Guid Guid { get; set; }
  }
}
