using System;
using System.Collections.Generic;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface IPictureDomainModelManager : IDomainModelManager<Int32, PictureTableModel, PictureDomainModel> {
    PictureDomainModel GetRepresentative(ApartmentDomainModel model);
    IEnumerable<PictureDomainModel> GetByApartment(ApartmentDomainModel model);
    Int32 MakeRepresentative(PictureDomainModel model);
  }
}
