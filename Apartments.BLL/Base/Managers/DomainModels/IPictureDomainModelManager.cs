using System;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface IPictureDomainModelManager : IDomainModelManager<Int32, PictureTableModel, PictureDomainModel> {
    PictureDomainModel GetRepresentative(ApartmentDomainModel model);
  }
}
