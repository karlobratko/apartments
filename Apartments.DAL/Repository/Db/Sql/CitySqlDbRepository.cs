using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.Repository.Db.Sql;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.DAL.Repository.Db.Sql {
  public class CitySqlDbRepository : BaseSqlDbRepository<Int32, CityTableModel>, ICityTableModelRepository {
    #region Constructors

    public CitySqlDbRepository(IConnectionStringManager connectionStringManager, ISqlDbTypeManager sqlDbTypeManager)
      : base(connectionStringManager, sqlDbTypeManager) {
    }

    #endregion

    #region Base Overrides

    public override String EntityName => "City";

    public override CityTableModel Model(SqlDataReader reader)
      => new CityTableModel {
        Id = reader.GetInt32(reader.GetOrdinal(nameof(CityTableModel.Id))),
        Guid = reader.GetGuid(reader.GetOrdinal(nameof(CityTableModel.Guid))),
        CreateDate = reader.GetDateTime(reader.GetOrdinal(nameof(CityTableModel.CreateDate))),
        CreatedBy = reader.GetInt32(reader.GetOrdinal(nameof(CityTableModel.CreatedBy))),
        UpdateDate = reader.GetDateTime(reader.GetOrdinal(nameof(CityTableModel.UpdateDate))),
        UpdatedBy = reader.GetInt32(reader.GetOrdinal(nameof(CityTableModel.UpdatedBy))),
        DeleteDate = !reader.IsDBNull(reader.GetOrdinal(nameof(CityTableModel.DeleteDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(CityTableModel.DeleteDate)))
          : (DateTime?)null,
        DeletedBy = !reader.IsDBNull(reader.GetOrdinal(nameof(CityTableModel.DeletedBy)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(CityTableModel.DeletedBy)))
          : (Int32?)null,
        Name = reader.GetString(reader.GetOrdinal(nameof(CityTableModel.Name))),
      };

    public override IList<SqlParameter> Parameterize(CityTableModel model)
      => new List<SqlParameter> {
        new SqlParameter { ParameterName = $"@{nameof(CityTableModel.Name)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(CityTableModel).GetProperty(nameof(CityTableModel.Name)).PropertyType), Value = model.Name },
      };

    #endregion
  }
}
