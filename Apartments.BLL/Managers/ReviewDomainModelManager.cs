using System;

using Apartments.BLL.Base.Managers;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class ReviewDomainModelManager : BaseDomainModelManager<Int32, ReviewTableModel, ReviewDomainModel>,
                                          IReviewDomainModelManager {

    #region Constructors

    public ReviewDomainModelManager(IReviewTableModelRepository repository) : base(repository) {
    }

    #endregion

  }
}
