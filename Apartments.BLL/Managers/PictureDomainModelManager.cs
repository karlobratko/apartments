using System;

using Apartments.BLL.Base.Managers;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class PictureDomainModelManager : BaseDomainModelManager<Int32, PictureTableModel, PictureDomainModel>,
                                           IPictureDomainModelManager {

    #region Constructors

    public PictureDomainModelManager(IPictureTableModelRepository repository) : base(repository) {
    }

    #endregion

  }
}
