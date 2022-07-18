using System;
using System.Collections.Generic;
using System.Linq;

using Apartments.BLL.Base.Managers;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class TagDomainModelManager : BaseDomainModelManager<Int32, TagTableModel, TagDomainModel>,
                                       ITagDomainModelManager {

    #region Constructors

    public TagDomainModelManager(ITagTableModelRepository repository) : base(repository) {
    }

    #endregion

    #region Public Methods

    public IEnumerable<TagDomainModel> GetUnassigned(ApartmentDomainModel model)
      => (Repository as ITagTableModelRepository).ReadUnassigned(apartmentFK: model.Id).Select(ToDomainModel);

    public IEnumerable<TagDomainModel> GetByApartment(ApartmentDomainModel model)
      => (Repository as ITagTableModelRepository).ReadByApartmentFK(apartmentFK: model.Id).Select(ToDomainModel);

    #endregion

  }
}
