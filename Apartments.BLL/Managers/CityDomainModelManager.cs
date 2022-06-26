using System;

using Apartments.BLL.Base.Managers;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class CityDomainModelManager : BaseDomainModelManager<Int32, CityTableModel, CityDomainModel>,
                                        ICityDomainModelManager {

    #region Constructors

    public CityDomainModelManager(ICityTableModelRepository repository) : base(repository) {
    }

    #endregion

  }
}
