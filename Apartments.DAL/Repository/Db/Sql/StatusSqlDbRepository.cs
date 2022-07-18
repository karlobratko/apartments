using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.Repository.Db.Sql;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.DAL.Repository.Db.Sql {
  public class StatusSqlDbRepository : BaseSqlDbRepository<Int32, StatusTableModel>, IStatusTableModelRepository {

    #region Constructors

    public StatusSqlDbRepository(IConnectionStringManager connectionStringManager, ISqlDbTypeManager sqlDbTypeManager)
      : base(connectionStringManager, sqlDbTypeManager) {
    }

    #endregion

    #region Base Overrides

    public override String EntityName => "Status";

    public override StatusTableModel Model(SqlDataReader reader)
      => new StatusTableModel {
        Id = reader.GetInt32(reader.GetOrdinal(nameof(StatusTableModel.Id))),
        Guid = reader.GetGuid(reader.GetOrdinal(nameof(StatusTableModel.Guid))),
        CreateDate = reader.GetDateTime(reader.GetOrdinal(nameof(StatusTableModel.CreateDate))),
        CreatedBy = reader.GetInt32(reader.GetOrdinal(nameof(StatusTableModel.CreatedBy))),
        UpdateDate = reader.GetDateTime(reader.GetOrdinal(nameof(StatusTableModel.UpdateDate))),
        UpdatedBy = reader.GetInt32(reader.GetOrdinal(nameof(StatusTableModel.UpdatedBy))),
        DeleteDate = !reader.IsDBNull(reader.GetOrdinal(nameof(StatusTableModel.DeleteDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(StatusTableModel.DeleteDate)))
          : (DateTime?)null,
        DeletedBy = !reader.IsDBNull(reader.GetOrdinal(nameof(StatusTableModel.DeletedBy)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(StatusTableModel.DeletedBy)))
          : (Int32?)null,
        Name = reader.GetString(reader.GetOrdinal(nameof(StatusTableModel.Name))),
        NameEng = reader.GetString(reader.GetOrdinal(nameof(StatusTableModel.NameEng))),
      };

    public override IList<SqlParameter> Parameterize(StatusTableModel model)
      => new List<SqlParameter> {
        new SqlParameter { ParameterName = $"@{nameof(StatusTableModel.Name)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(StatusTableModel).GetProperty(nameof(StatusTableModel.Name)).PropertyType), Value = model.Name },
        new SqlParameter { ParameterName = $"@{nameof(StatusTableModel.NameEng)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(StatusTableModel).GetProperty(nameof(StatusTableModel.NameEng)).PropertyType), Value = model.NameEng },
      };

    #endregion

  }
}
