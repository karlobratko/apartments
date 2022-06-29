using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Apartments.BLL.Base.Managers.DomainModels;
using Apartments.BLL.Managers;
using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.Managers;
using Apartments.DAL.Repository.Db.Sql;

using Ninject;

namespace Apartments.WebUI.Infrastructure {
  public class NinjectDependencyResolver : IDependencyResolver {
    private readonly IKernel _kernel;

    public NinjectDependencyResolver(IKernel kernel) {
      _kernel = kernel;
      AddBindings();
    }

    #region Private Methods

    private void AddBindings() {
      _ = _kernel.Bind<IConnectionStringManager>().To<ConnectionStringManager>().InSingletonScope();
      _ = _kernel.Bind<ISqlDbTypeManager>().To<SqlDbTypeManager>().InSingletonScope();

      _ = _kernel.Bind<IApartmentTableModelRepository>().To<ApartmentSqlDbRepository>().InSingletonScope();
      _ = _kernel.Bind<ICityTableModelRepository>().To<CitySqlDbRepository>().InSingletonScope();
      _ = _kernel.Bind<IOwnerTableModelRepository>().To<OwnerSqlDbRepository>().InSingletonScope();
      _ = _kernel.Bind<IPictureTableModelRepository>().To<PictureSqlDbRepository>().InSingletonScope();
      _ = _kernel.Bind<IReservationTableModelRepository>().To<ReservationSqlDbRepository>().InSingletonScope();
      _ = _kernel.Bind<IReviewTableModelRepository>().To<ReviewSqlDbRepository>().InSingletonScope();
      _ = _kernel.Bind<IStatusTableModelRepository>().To<StatusSqlDbRepository>().InSingletonScope();
      _ = _kernel.Bind<ITagApartmentTableModelRepository>().To<TagApartmentSqlDbRepository>().InSingletonScope();
      _ = _kernel.Bind<ITagTableModelRepository>().To<TagSqlDbRepository>().InSingletonScope();
      _ = _kernel.Bind<ITagTypeTableModelRepository>().To<TagTypeSqlDbRepository>().InSingletonScope();
      _ = _kernel.Bind<IUserTableModelRepository>().To<UserSqlDbRepository>().InSingletonScope();

      _ = _kernel.Bind<IApartmentDomainModelManager>().To<ApartmentDomainModelManager>();
      _ = _kernel.Bind<ICityDomainModelManager>().To<CityDomainModelManager>();
      _ = _kernel.Bind<IOwnerDomainModelManager>().To<OwnerDomainModelManager>();
      _ = _kernel.Bind<IPictureDomainModelManager>().To<PictureDomainModelManager>();
      _ = _kernel.Bind<IReservationDomainModelManager>().To<ReservationDomainModelManager>();
      _ = _kernel.Bind<IReviewDomainModelManager>().To<ReviewDomainModelManager>();
      _ = _kernel.Bind<IStatusDomainModelManager>().To<StatusDomainModelManager>();
      _ = _kernel.Bind<ITagApartmentDomainModelManager>().To<TagApartmentDomainModelManager>();
      _ = _kernel.Bind<ITagDomainModelManager>().To<TagDomainModelManager>();
      _ = _kernel.Bind<ITagTypeDomainModelManager>().To<TagTypeDomainModelManager>();
      _ = _kernel.Bind<IUserDomainModelManager>().To<UserDomainModelManager>();
    }

    #endregion

    #region Public Methods

    public Object GetService(Type serviceType) => _kernel.TryGet(service: serviceType);
    public IEnumerable<Object> GetServices(Type serviceType) => _kernel.GetAll(service: serviceType);

    #endregion
  }
}