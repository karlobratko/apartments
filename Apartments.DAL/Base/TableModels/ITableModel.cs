namespace Apartments.DAL.Base.TableModels {
  public interface ITableModel<TKey> : IIdentifiable<TKey>, IManageable<TKey>
    where TKey : struct {
  }
}
