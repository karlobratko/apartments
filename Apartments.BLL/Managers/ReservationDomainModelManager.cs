using System;

using Apartments.BLL.Base.Managers;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class ReservationDomainModelManager : BaseDomainModelManager<Int32, ReservationTableModel, ReservationDomainModel>,
                                               IReservationDomainModelManager {

    #region Constructors

    public ReservationDomainModelManager(IReservationTableModelRepository repository) : base(repository) {
    }

    #endregion

  }
}
