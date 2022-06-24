using System;

namespace Apartments.DAL.Base.Managers {
  public interface IConnectionStringManager {
    String ConnectionString { get; }
    String GetConnectionString();
  }
}
