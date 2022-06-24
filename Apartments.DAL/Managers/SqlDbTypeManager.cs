using System;
using System.Collections.Generic;
using System.Data;

using Apartments.DAL.Base.Managers;

namespace Apartments.DAL.Managers {
  public class SqlDbTypeManager : ISqlDbTypeManager {
    private readonly Dictionary<Type, SqlDbType> _typeDictionary =
      new Dictionary<Type, SqlDbType> {
        { typeof(String),         SqlDbType.NVarChar },
        { typeof(Char[]),         SqlDbType.NVarChar },
        { typeof(Byte),           SqlDbType.TinyInt },
        { typeof(Int16),          SqlDbType.SmallInt },
        { typeof(Int32),          SqlDbType.Int },
        { typeof(Int32?),         SqlDbType.Int },
        { typeof(Int64),          SqlDbType.BigInt },
        { typeof(Int64?),         SqlDbType.BigInt },
        { typeof(Byte[]),         SqlDbType.Image },
        { typeof(Boolean),        SqlDbType.Bit },
        { typeof(Boolean?),       SqlDbType.Bit },
        { typeof(DateTime),       SqlDbType.DateTime },
        { typeof(DateTime?),      SqlDbType.DateTime },
        { typeof(DateTimeOffset), SqlDbType.DateTimeOffset },
        { typeof(Decimal),        SqlDbType.Decimal },
        { typeof(Decimal?),       SqlDbType.Decimal },
        { typeof(Single),         SqlDbType.Real },
        { typeof(Double),         SqlDbType.Float },
        { typeof(TimeSpan),       SqlDbType.Time },
        { typeof(Guid),           SqlDbType.UniqueIdentifier },
      };

    public SqlDbType GetSqlDbType(Type type) => _typeDictionary[type];
    public SqlDbType GetSqlDbType<Type>() => GetSqlDbType(typeof(Type));
  }
}
