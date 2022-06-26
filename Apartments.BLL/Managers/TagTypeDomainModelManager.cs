using System;

using Apartments.BLL.Base.Managers;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class TagTypeDomainModelManager : BaseDomainModelManager<Int32, TagTypeTableModel, TagTypeDomainModel>,
                                           ITagTypeDomainModelManager {

    #region Constructors

    public TagTypeDomainModelManager(ITagTypeTableModelRepository repository) : base(repository) {
    }

    #endregion

  }
}
