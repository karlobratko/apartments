using System;

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

  }
}
