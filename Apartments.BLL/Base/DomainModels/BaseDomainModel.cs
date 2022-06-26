using System;

namespace Apartments.BLL.Base.DomainModels {
  public abstract class BaseDomainModel<TKey> : IDomainModel<TKey>
    where TKey : struct {
    public TKey Id { get; set; }
    public Guid Guid { get; set; }
    public Boolean IsAvailable { get; }
  }
}
