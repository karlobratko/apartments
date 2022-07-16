using System;
using System.Collections.Generic;

using Apartments.DAL.Enums;
using Apartments.DAL.TableModels;

namespace Apartments.DAL.Base.Repository.TableModels {
  public interface IPictureTableModelRepository : ITableModelRepository<Int32, PictureTableModel> {
    PictureTableModel ReadRepresentative(Int32 apartmentFK);
    IEnumerable<PictureTableModel> ReadByApartmentFK(Int32 apartmentFK);
    OperationStatus MakeRepresentative(Guid guid);
    OperationStatus MakeRepresentative(Guid guid, Int32? updatedBy);
  }
}
