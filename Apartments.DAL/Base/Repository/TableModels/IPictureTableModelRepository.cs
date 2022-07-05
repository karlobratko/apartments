using System;

using Apartments.DAL.TableModels;

namespace Apartments.DAL.Base.Repository.TableModels {
  public interface IPictureTableModelRepository : ITableModelRepository<Int32, PictureTableModel> {
    PictureTableModel ReadRepresentative(Int32 apartmentFK);
  }
}
