using System;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface IReviewDomainModelManager : IDomainModelManager<Int32, ReviewTableModel, ReviewDomainModel> {
  }
}
