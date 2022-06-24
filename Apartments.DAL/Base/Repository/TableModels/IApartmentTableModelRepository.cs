using System;

using Apartments.DAL.TableModels;

namespace Apartments.DAL.Base.Repository.TableModels {
  public interface IApartmentTableModelRepository : ITableModelRepository<Int32, ApartmentTableModel> {
  }
}
