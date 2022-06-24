using System;
using System.Configuration;

using Apartments.DAL.Base.Managers;

namespace Apartments.DAL.Managers {
  public class ConnectionStringManager : IConnectionStringManager {
    public String ConnectionString => ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

    public String GetConnectionString() => ConnectionString;
  }
}
