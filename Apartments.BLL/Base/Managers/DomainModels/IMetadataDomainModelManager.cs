using System;

using Apartments.BLL.DomainModels;
using Apartments.DAL.TableModels;

namespace Apartments.BLL.Base.Managers.DomainModels {
  public interface IMetadataDomainModelManager : IDomainModelManager<Int32, MetadataTableModel, MetadataDomainModel> {
    MetadataDomainModel GetMetadata();
  }
}
