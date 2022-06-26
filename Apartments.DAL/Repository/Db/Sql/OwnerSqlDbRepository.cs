using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.Repository.Db.Sql;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.DAL.Repository.Db.Sql {
  public class OwnerSqlDbRepository : BaseSqlDbRepository<Int32, OwnerTableModel>, IOwnerTableModelRepository {

    #region Constructors

    public OwnerSqlDbRepository(IConnectionStringManager connectionStringManager, ISqlDbTypeManager sqlDbTypeManager)
      : base(connectionStringManager, sqlDbTypeManager) {
    }

    #endregion

    #region Base Overrides

    public override String EntityName => "Owner";

    public override OwnerTableModel Model(SqlDataReader reader)
      => new OwnerTableModel {
        Id = reader.GetInt32(reader.GetOrdinal(nameof(OwnerTableModel.Id))),
        Guid = reader.GetGuid(reader.GetOrdinal(nameof(OwnerTableModel.Guid))),
        CreateDate = reader.GetDateTime(reader.GetOrdinal(nameof(OwnerTableModel.CreateDate))),
        CreatedBy = reader.GetInt32(reader.GetOrdinal(nameof(OwnerTableModel.CreatedBy))),
        UpdateDate = reader.GetDateTime(reader.GetOrdinal(nameof(OwnerTableModel.UpdateDate))),
        UpdatedBy = reader.GetInt32(reader.GetOrdinal(nameof(OwnerTableModel.UpdatedBy))),
        DeleteDate = !reader.IsDBNull(reader.GetOrdinal(nameof(OwnerTableModel.DeleteDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(OwnerTableModel.DeleteDate)))
          : (DateTime?)null,
        DeletedBy = !reader.IsDBNull(reader.GetOrdinal(nameof(OwnerTableModel.DeletedBy)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(OwnerTableModel.DeletedBy)))
          : (Int32?)null,
        Name = reader.GetString(reader.GetOrdinal(nameof(OwnerTableModel.Name))),
      };

    public override IList<SqlParameter> Parameterize(OwnerTableModel model)
      => new List<SqlParameter> {
        new SqlParameter { ParameterName = $"@{nameof(OwnerTableModel.Name)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(OwnerTableModel).GetProperty(nameof(OwnerTableModel.Name)).PropertyType), Value = model.Name },
      };

    #endregion

  }
}
