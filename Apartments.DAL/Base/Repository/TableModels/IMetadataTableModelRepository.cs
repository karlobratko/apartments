using System;

using Apartments.DAL.TableModels;

namespace Apartments.DAL.Base.Repository.TableModels {
  public interface IMetadataTableModelRepository : ITableModelRepository<Int32, MetadataTableModel> {
    MetadataTableModel Read();
  }
}
