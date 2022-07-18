using System;

using Apartments.DAL.TableModels;

namespace Apartments.DAL.Base.Repository.TableModels {
  public interface IReservationTableModelRepository : ITableModelRepository<Int32, ReservationTableModel> {
  }
}
