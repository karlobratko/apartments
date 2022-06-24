using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.Repository.Db.Sql;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.Managers;

using Apartments.DAL.TableModels;

namespace Apartments.DAL.Repository.Db.Sql {
  public class TagApartmentSqlDbRepository : BaseSqlDbRepository<Int32, TagApartmentTableModel>, ITagApartmentTableModelRepository {
    #region Constructors

    public TagApartmentSqlDbRepository(IConnectionStringManager connectionStringManager, ISqlDbTypeManager sqlDbTypeManager)
      : base(connectionStringManager, sqlDbTypeManager) {
    }

    #endregion

    #region Base Overrides

    public override String EntityName => "TagApartment";

    public override TagApartmentTableModel Model(SqlDataReader reader)
      => new TagApartmentTableModel {
        Id = reader.GetInt32(reader.GetOrdinal(nameof(TagApartmentTableModel.Id))),
        Guid = reader.GetGuid(reader.GetOrdinal(nameof(TagApartmentTableModel.Guid))),
        CreateDate = reader.GetDateTime(reader.GetOrdinal(nameof(TagApartmentTableModel.CreateDate))),
        CreatedBy = reader.GetInt32(reader.GetOrdinal(nameof(TagApartmentTableModel.CreatedBy))),
        UpdateDate = reader.GetDateTime(reader.GetOrdinal(nameof(TagApartmentTableModel.UpdateDate))),
        UpdatedBy = reader.GetInt32(reader.GetOrdinal(nameof(TagApartmentTableModel.UpdatedBy))),
        DeleteDate = !reader.IsDBNull(reader.GetOrdinal(nameof(TagApartmentTableModel.DeleteDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(TagApartmentTableModel.DeleteDate)))
          : (DateTime?)null,
        DeletedBy = !reader.IsDBNull(reader.GetOrdinal(nameof(TagApartmentTableModel.DeletedBy)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(TagApartmentTableModel.DeletedBy)))
          : (Int32?)null,
        TagFK = reader.GetInt32(reader.GetOrdinal(nameof(TagApartmentTableModel.TagFK))),
        ApartmentFK = reader.GetInt32(reader.GetOrdinal(nameof(TagApartmentTableModel.ApartmentFK))),
      };

    public override IList<SqlParameter> Parameterize(TagApartmentTableModel model)
      => new List<SqlParameter> {
        new SqlParameter { ParameterName = $"@{nameof(TagApartmentTableModel.TagFK)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(TagApartmentTableModel).GetProperty(nameof(TagApartmentTableModel.TagFK)).PropertyType), Value = model.TagFK },
        new SqlParameter { ParameterName = $"@{nameof(TagApartmentTableModel.ApartmentFK)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(TagApartmentTableModel).GetProperty(nameof(TagApartmentTableModel.ApartmentFK)).PropertyType), Value = model.ApartmentFK },
      };

    #endregion
  }
}
