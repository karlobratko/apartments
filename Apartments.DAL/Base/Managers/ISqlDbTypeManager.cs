using System;
using System.Data;

namespace Apartments.DAL.Base.Managers {
  public interface ISqlDbTypeManager {
    SqlDbType GetSqlDbType(Type type);
    SqlDbType GetSqlDbType<Type>();
  }
}
