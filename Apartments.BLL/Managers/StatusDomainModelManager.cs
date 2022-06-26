using System;

using Apartments.BLL.Base.Managers;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class StatusDomainModelManager : BaseDomainModelManager<Int32, StatusTableModel, StatusDomainModel> {

    #region Constructors

    public StatusDomainModelManager(IStatusTableModelRepository repository) : base(repository) {
    }

    #endregion

  }
}
