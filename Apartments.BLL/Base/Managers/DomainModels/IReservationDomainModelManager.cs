using System;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface IReservationDomainModelManager : IDomainModelManager<Int32, ReservationTableModel, ReservationDomainModel> {
  }
}
