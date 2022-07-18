using System;

namespace Apartments.DAL.Base.TableModels {
  public interface IManageable<TKey> 
    where TKey : struct {
    DateTime CreateDate { get; set; }
    TKey CreatedBy { get; set; }
    DateTime UpdateDate { get; set; }
    TKey UpdatedBy { get; set; }
    DateTime? DeleteDate { get; set; }
    TKey? DeletedBy { get; set; }
  }
}
