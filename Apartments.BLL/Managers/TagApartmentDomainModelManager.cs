using System;
using System.Collections.Generic;
using System.Linq;

using Apartments.BLL.Base.Managers;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class TagApartmentDomainModelManager : BaseDomainModelManager<Int32, TagApartmentTableModel, TagApartmentDomainModel>,
                                                   ITagApartmentDomainModelManager {

    #region Constructors

    public TagApartmentDomainModelManager(ITagApartmentTableModelRepository repository) : base(repository) {
    }

    #endregion

    #region Public Methods

    public IEnumerable<TagApartmentDomainModel> GetByApartment(ApartmentDomainModel model)
      => (Repository as ITagApartmentTableModelRepository).ReadByApartmentFK(apartmentFK: model.Id).Select(ToDomainModel);

    #endregion

  }
}
