using System;
using System.Collections.Generic;

using Apartments.DAL.TableModels;

namespace Apartments.DAL.Base.Repository.TableModels {
  public interface ITagTableModelRepository : ITableModelRepository<Int32, TagTableModel> {
    IEnumerable<TagTableModel> ReadUnassigned(Int32 apartmentFK);
    IEnumerable<TagTableModel> ReadByApartmentFK(Int32 apartmentFK);
  }
}
