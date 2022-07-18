using System;
using System.Collections.Generic;

using Apartments.DAL.TableModels;

namespace Apartments.DAL.Base.Repository.TableModels {
  public interface ITagApartmentTableModelRepository : ITableModelRepository<Int32, TagApartmentTableModel> {
    IEnumerable<TagApartmentTableModel> ReadByApartmentFK(Int32 apartmentFK);
  }
}
