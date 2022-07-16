using System;
using System.Collections.Generic;
using System.Linq;

using Apartments.BLL.Base.Managers;
using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.Enums;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class PictureDomainModelManager : BaseDomainModelManager<Int32, PictureTableModel, PictureDomainModel>,
                                           IPictureDomainModelManager {

    #region Constructors

    public PictureDomainModelManager(IPictureTableModelRepository repository) : base(repository) {
    }

    #endregion

    #region Public Methods

    public PictureDomainModel GetRepresentative(ApartmentDomainModel model) {
      PictureTableModel tableModel = (Repository as IPictureTableModelRepository).ReadRepresentative(apartmentFK: model.Id);
      return !(tableModel is null)
        ? ToDomainModel(tableModel)
        : null;
    }

    public IEnumerable<PictureDomainModel> GetByApartment(ApartmentDomainModel model)
      => (Repository as IPictureTableModelRepository).ReadByApartmentFK(apartmentFK: model.Id).Select(ToDomainModel);
    public Int32 MakeRepresentative(PictureDomainModel model) {
      OperationStatus operationStatus = (Repository as IPictureTableModelRepository).MakeRepresentative(guid: model.Guid);

      switch (operationStatus) {
        case OperationStatus.Failure:
          return 0;
        case OperationStatus.Success:
          return 1;
        default:
          throw new InvalidOperationException();
      }
    }

    #endregion

  }
}
