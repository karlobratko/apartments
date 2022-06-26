using System;

using Apartments.BLL.Base.Managers;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class OwnerDomainModelManager : BaseDomainModelManager<Int32, OwnerTableModel, OwnerDomainModel>,
                                         IOwnerDomainModelManager {

    #region Constructors

    public OwnerDomainModelManager(IOwnerTableModelRepository repository) : base(repository) {
    }

    #endregion

  }
}
