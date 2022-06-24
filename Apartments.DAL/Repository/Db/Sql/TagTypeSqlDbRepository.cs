using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.Repository.Db.Sql;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.Managers;

using Apartments.DAL.TableModels;

namespace Apartments.DAL.Repository.Db.Sql {
  public class TagTypeSqlDbRepository : BaseSqlDbRepository<Int32, TagTypeTableModel>, ITagTypeTableModelRepository {
    #region Constructors

    public TagTypeSqlDbRepository(IConnectionStringManager connectionStringManager, ISqlDbTypeManager sqlDbTypeManager)
      : base(connectionStringManager, sqlDbTypeManager) {
    }

    #endregion

    #region Base Overrides

    public override String EntityName => "TagType";

    public override TagTypeTableModel Model(SqlDataReader reader)
      => new TagTypeTableModel {
        Id = reader.GetInt32(reader.GetOrdinal(nameof(TagTypeTableModel.Id))),
        Guid = reader.GetGuid(reader.GetOrdinal(nameof(TagTypeTableModel.Guid))),
        CreateDate = reader.GetDateTime(reader.GetOrdinal(nameof(TagTypeTableModel.CreateDate))),
        CreatedBy = reader.GetInt32(reader.GetOrdinal(nameof(TagTypeTableModel.CreatedBy))),
        UpdateDate = reader.GetDateTime(reader.GetOrdinal(nameof(TagTypeTableModel.UpdateDate))),
        UpdatedBy = reader.GetInt32(reader.GetOrdinal(nameof(TagTypeTableModel.UpdatedBy))),
        DeleteDate = !reader.IsDBNull(reader.GetOrdinal(nameof(TagTypeTableModel.DeleteDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(TagTypeTableModel.DeleteDate)))
          : (DateTime?)null,
        DeletedBy = !reader.IsDBNull(reader.GetOrdinal(nameof(TagTypeTableModel.DeletedBy)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(TagTypeTableModel.DeletedBy)))
          : (Int32?)null,
        Name = reader.GetString(reader.GetOrdinal(nameof(TagTypeTableModel.Name))),
        NameEng = reader.GetString(reader.GetOrdinal(nameof(TagTypeTableModel.NameEng))),
      };

    public override IList<SqlParameter> Parameterize(TagTypeTableModel model)
      => new List<SqlParameter> {
        new SqlParameter { ParameterName = $"@{nameof(TagTypeTableModel.Name)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(TagTypeTableModel).GetProperty(nameof(TagTypeTableModel.Name)).PropertyType), Value = model.Name },
        new SqlParameter { ParameterName = $"@{nameof(TagTypeTableModel.NameEng)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(TagTypeTableModel).GetProperty(nameof(TagTypeTableModel.NameEng)).PropertyType), Value = model.NameEng }
      };

    #endregion
  }
}
