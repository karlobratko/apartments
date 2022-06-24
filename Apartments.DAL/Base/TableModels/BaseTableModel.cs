using System;

namespace Apartments.DAL.Base.TableModels {
  public abstract class BaseTableModel<TKey> : ITableModel<TKey>
    where TKey : struct {
    public TKey Id { get; set; }
    public Guid Guid { get; set; }
    public DateTime CreateDate { get; set; }
    public TKey CreatedBy { get; set; }
    public DateTime UpdateDate { get; set; }
    public TKey UpdatedBy { get; set; }
    public DateTime? DeleteDate { get; set; }
    public TKey? DeletedBy { get; set; }
  }
}
