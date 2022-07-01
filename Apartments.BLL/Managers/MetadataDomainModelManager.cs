using System;
using System.Collections.Generic;

using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.DomainModels;
using Apartments.DAL.Base.Repository;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Managers {
  public class MetadataDomainModelManager : IMetadataDomainModelManager {

    #region Private Properties

    private readonly ICityDomainModelManager _cityManager;

    #endregion

    #region Constructors

    public MetadataDomainModelManager(IMetadataTableModelRepository repository, ICityDomainModelManager cityManager) {
      Repository = repository;
      _cityManager = cityManager;
    }

    #endregion

    #region Public Properties

    public ITableModelRepository<Int32, MetadataTableModel> Repository { get; }

    #endregion

    #region Public Methods

    public MetadataDomainModel ToDomainModel(MetadataTableModel model)
      => new MetadataDomainModel {
        Id = model.Id,
        Guid = model.Guid,
        Name = model.Name,
        OIB = model.OIB,
        City = _cityManager.GetById(id: model.CityFK),
        Address = model.Address,
        Telephone = model.Telephone,
        Mobile = model.Mobile,
        Email = model.Email
      };

    public MetadataDomainModel GetMetadata()
      => ToDomainModel((Repository as IMetadataTableModelRepository).Read());

    #endregion

    #region Unimplemented

    public MetadataDomainModel Add(MetadataDomainModel model) => throw new NotImplementedException();
    public MetadataDomainModel Add(MetadataDomainModel model, Int32 createdBy) => throw new NotImplementedException();
    public Int32 Edit(MetadataDomainModel model) => throw new NotImplementedException();
    public Int32 Edit(Guid guid, MetadataDomainModel model) => throw new NotImplementedException();
    public Int32 Edit(MetadataDomainModel model, Int32 updatedBy) => throw new NotImplementedException();
    public Int32 Edit(Guid guid, MetadataDomainModel model, Int32 updatedBy) => throw new NotImplementedException();
    public IEnumerable<MetadataDomainModel> GetAll() => throw new NotImplementedException();
    public IEnumerable<MetadataDomainModel> GetAllIfAvailable() => throw new NotImplementedException();
    public Int32 Remove(MetadataDomainModel model) => throw new NotImplementedException();
    public Int32 Remove(Guid guid) => throw new NotImplementedException();
    public Int32 Remove(MetadataDomainModel model, Int32 deletedBy) => throw new NotImplementedException();
    public Int32 Remove(Guid guid, Int32 deletedBy) => throw new NotImplementedException();
    public MetadataTableModel ToTableModel(MetadataDomainModel model) => throw new NotImplementedException();
    public MetadataDomainModel GetById(Int32 guid) => throw new NotImplementedException();
    public MetadataDomainModel GetByIdIfAvailable(Int32 guid) => throw new NotImplementedException();

    #endregion
  }
}
