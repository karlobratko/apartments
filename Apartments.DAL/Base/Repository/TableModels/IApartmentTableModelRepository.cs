using System;
using System.Collections.Generic;

using Apartments.DAL.TableModels;

namespace Apartments.DAL.Base.Repository.TableModels {
  public interface IApartmentTableModelRepository : ITableModelRepository<Int32, ApartmentTableModel> {
    IEnumerable<ApartmentTableModel> ReadByTagFK(Int32 tagFK);
  }
}
