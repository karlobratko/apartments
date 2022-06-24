using System;
using System.Collections.Generic;
using System.Data;

namespace Apartments.DAL.Base.Repository.Db {
  public interface IDbRepository {
    String ConnectionString { get; }
    String EntityName { get; }
  }
}
