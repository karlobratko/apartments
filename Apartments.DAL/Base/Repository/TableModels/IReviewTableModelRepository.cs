using System;
using System.Collections.Generic;

using Apartments.DAL.TableModels;

namespace Apartments.DAL.Base.Repository.TableModels {
  public interface IReviewTableModelRepository : ITableModelRepository<Int32, ReviewTableModel> {
    IEnumerable<ReviewTableModel> ReadByApartmentFK(Int32 apartmentFK);
  }
}
