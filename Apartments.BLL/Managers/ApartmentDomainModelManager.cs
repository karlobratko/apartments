using System;
using System.Collections.Generic;
using System.Linq;

using Apartments.BLL.Base.Managers;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class ApartmentDomainModelManager : BaseDomainModelManager<Int32, ApartmentTableModel, ApartmentDomainModel>,
                                             IApartmentDomainModelManager {

    #region Constructors

    public ApartmentDomainModelManager(IApartmentTableModelRepository repository) : base(repository) {
    }

    #endregion

    #region Public Methods

    public IEnumerable<ApartmentDomainModel> GetByTag(TagDomainModel tag)
      => (Repository as IApartmentTableModelRepository).ReadByTagFK(tagFK: tag.Id).Select(ToDomainModel);

    #endregion

  }
}
