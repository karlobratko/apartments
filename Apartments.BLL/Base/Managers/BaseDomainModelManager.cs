using System;
using System.Collections.Generic;
using System.Linq;

using Apartments.BLL.Base.DomainModels;
using Apartments.DAL.Base.Repository;
using Apartments.DAL.Base.TableModels;
using Apartments.DAL.Enums;

namespace Apartments.BLL.Base.Managers {
  public abstract class BaseDomainModelManager<TKey, TTableModel, TDomainModel> : IDomainModelManager<TKey, TTableModel, TDomainModel>
    where TTableModel : class, ITableModel<TKey>
    where TDomainModel : class, IDomainModel<TKey>
    where TKey : struct {

    #region Constructors

    public BaseDomainModelManager(ITableModelRepository<TKey, TTableModel> repository) => Repository = repository;

    #endregion

    #region Public Properties

    public ITableModelRepository<TKey, TTableModel> Repository { get; }

    #endregion

    #region Overridable

    public virtual TDomainModel ToDomainModel(TTableModel model)
  => typeof(TDomainModel).GetProperties()
                         .Aggregate(seed: Activator.CreateInstance<TDomainModel>(),
                                    func: (obj, property) => {
                                      if (!(model.GetType().GetProperty(property.Name) is null)) {
                                        obj.GetType()
                                           .GetProperty(property.Name)
                                           .SetValue(obj, model.GetType().GetProperty(property.Name).GetValue(model));
                                      }

                                      return obj;
                                    });
    public virtual TTableModel ToTableModel(TDomainModel model)
      => typeof(TTableModel).GetProperties()
                            .Aggregate(seed: Activator.CreateInstance<TTableModel>(),
                                       func: (obj, property) => {
                                         if (!(model.GetType().GetProperty(property.Name) is null)) {
                                           obj.GetType()
                                              .GetProperty(property.Name)
                                              .SetValue(obj, model.GetType().GetProperty(property.Name).GetValue(model));
                                         }

                                         return obj;
                                       });

    #endregion

    #region Add
    public TDomainModel Add(TDomainModel model) {
      TTableModel tableModel = Repository.Create(model: ToTableModel(model),
                                                 createStatus: out CreateStatus createStatus);

      switch (createStatus) {
        case CreateStatus.InternalError:
          return null;
        case CreateStatus.Success:
        case CreateStatus.UniquenessViolated:
        case CreateStatus.Recreated:
          return ToDomainModel(model: tableModel);
        default:
          throw new InvalidOperationException();
      }
    }
    public TDomainModel Add(TDomainModel model, TKey createdBy) {
      TTableModel tableModel = Repository.Create(model: ToTableModel(model),
                                                 createdBy: createdBy,
                                                 createStatus: out CreateStatus createStatus);

      switch (createStatus) {
        case CreateStatus.InternalError:
          return null;
        case CreateStatus.Success:
        case CreateStatus.UniquenessViolated:
        case CreateStatus.Recreated:
          return ToDomainModel(model: tableModel);
        default:
          throw new InvalidOperationException();
      }
    }

    #endregion

    #region Edit

    public Int32 Edit(TDomainModel model)
      => Edit(guid: model.Guid, model: model);
    public Int32 Edit(Guid guid, TDomainModel model) {
      UpdateStatus updateStatus = Repository.Update(guid: guid,
                                                    model: ToTableModel(model: model));

      switch (updateStatus) {
        case UpdateStatus.InternalError:
        case UpdateStatus.NotExists:
        case UpdateStatus.Deleted:
        case UpdateStatus.UniquenessViolated:
          return 0;
        case UpdateStatus.Success:
          return 1;
        default:
          throw new InvalidOperationException();
      }
    }

    public Int32 Edit(TDomainModel model, TKey updatedBy)
      => Edit(guid: model.Guid, model: model, updatedBy: updatedBy);
    public Int32 Edit(Guid guid, TDomainModel model, TKey updatedBy) {
      UpdateStatus updateStatus = Repository.Update(guid: guid,
                                                    model: ToTableModel(model: model),
                                                    updatedBy: updatedBy);

      switch (updateStatus) {
        case UpdateStatus.InternalError:
        case UpdateStatus.NotExists:
        case UpdateStatus.Deleted:
        case UpdateStatus.UniquenessViolated:
          return 0;
        case UpdateStatus.Success:
          return 1;
        default:
          throw new InvalidOperationException();
      }
    }

    #endregion

    #region Get

    public IEnumerable<TDomainModel> GetAll()
      => Repository.ReadAll().Select(ToDomainModel);

    public IEnumerable<TDomainModel> GetAllIfAvailable()
      => Repository.ReadAllAvailable().Select(ToDomainModel);

    public TDomainModel GetByGuid(Guid guid) {
      TTableModel model = Repository.ReadByGuid(guid: guid);
      return !(model is null)
        ? ToDomainModel(model)
        : null;
    }

    public TDomainModel GetByGuidIfAvailable(Guid guid) {
      TTableModel model = Repository.ReadByGuidAvailable(guid: guid);
      return !(model is null)
        ? ToDomainModel(model)
        : null;
    }

    #endregion

    #region Remove

    public Int32 Remove(TDomainModel model)
      => Remove(guid: model.Guid);
    public Int32 Remove(Guid guid) {
      DeleteStatus deleteStatus = Repository.Delete(guid: guid);

      switch (deleteStatus) {
        case DeleteStatus.InternalError:
        case DeleteStatus.NotExists:
        case DeleteStatus.AlreadyDeleted:
          return 0;
        case DeleteStatus.Success:
          return 1;
        default:
          throw new InvalidOperationException();
      }
    }

    public Int32 Remove(TDomainModel model, TKey deletedBy)
      => Remove(guid: model.Guid, deletedBy: deletedBy);
    public Int32 Remove(Guid guid, TKey deletedBy) {
      DeleteStatus deleteStatus = Repository.Delete(guid: guid,
                                                    deletedBy: deletedBy);

      switch (deleteStatus) {
        case DeleteStatus.InternalError:
        case DeleteStatus.NotExists:
        case DeleteStatus.AlreadyDeleted:
          return 0;
        case DeleteStatus.Success:
          return 1;
        default:
          throw new InvalidOperationException();
      }
    }

    #endregion

  }
}
