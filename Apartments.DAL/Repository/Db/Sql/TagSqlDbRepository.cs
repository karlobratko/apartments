using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.Repository.Db.Sql;
using Apartments.DAL.Base.Repository.TableModels;

using Apartments.DAL.TableModels;

namespace Apartments.DAL.Repository.Db.Sql {
  public class TagSqlDbRepository : BaseSqlDbRepository<Int32, TagTableModel>, ITagTableModelRepository {

    #region Constructors

    public TagSqlDbRepository(IConnectionStringManager connectionStringManager, ISqlDbTypeManager sqlDbTypeManager)
      : base(connectionStringManager, sqlDbTypeManager) {
    }

    #endregion

    #region Base Overrides

    public override String EntityName => "Tag";

    public override TagTableModel Model(SqlDataReader reader)
      => new TagTableModel {
        Id = reader.GetInt32(reader.GetOrdinal(nameof(TagTableModel.Id))),
        Guid = reader.GetGuid(reader.GetOrdinal(nameof(TagTableModel.Guid))),
        CreateDate = reader.GetDateTime(reader.GetOrdinal(nameof(TagTableModel.CreateDate))),
        CreatedBy = reader.GetInt32(reader.GetOrdinal(nameof(TagTableModel.CreatedBy))),
        UpdateDate = reader.GetDateTime(reader.GetOrdinal(nameof(TagTableModel.UpdateDate))),
        UpdatedBy = reader.GetInt32(reader.GetOrdinal(nameof(TagTableModel.UpdatedBy))),
        DeleteDate = !reader.IsDBNull(reader.GetOrdinal(nameof(TagTableModel.DeleteDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(TagTableModel.DeleteDate)))
          : (DateTime?)null,
        DeletedBy = !reader.IsDBNull(reader.GetOrdinal(nameof(TagTableModel.DeletedBy)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(TagTableModel.DeletedBy)))
          : (Int32?)null,
        Name = reader.GetString(reader.GetOrdinal(nameof(TagTableModel.Name))),
        NameEng = reader.GetString(reader.GetOrdinal(nameof(TagTableModel.NameEng))),
        TagTypeFK = reader.GetInt32(reader.GetOrdinal(nameof(TagTableModel.TagTypeFK))),
      };

    public override IList<SqlParameter> Parameterize(TagTableModel model)
      => new List<SqlParameter> {
        new SqlParameter { ParameterName = $"@{nameof(TagTableModel.Name)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(TagTableModel).GetProperty(nameof(TagTableModel.Name)).PropertyType), Value = model.Name },
        new SqlParameter { ParameterName = $"@{nameof(TagTableModel.NameEng)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(TagTableModel).GetProperty(nameof(TagTableModel.NameEng)).PropertyType), Value = model.NameEng },
        new SqlParameter { ParameterName = $"@{nameof(TagTableModel.TagTypeFK)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(TagTableModel).GetProperty(nameof(TagTableModel.TagTypeFK)).PropertyType), Value = model.TagTypeFK },
      };

    #endregion

    #region MyRegion

    public IEnumerable<TagTableModel> ReadUnassigned(Int32 apartmentFK) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@ApartmentFK",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.Id)).PropertyType),
          Value = apartmentFK
        }
      };

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(TagSqlDbRepository.ReadUnassigned)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        while (reader.Read()) {
          yield return Model(reader: reader);
        }
      }
    }

    public IEnumerable<TagTableModel> ReadByApartmentFK(Int32 apartmentFK) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@ApartmentFK",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.Id)).PropertyType),
          Value = apartmentFK
        }
      };

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(TagSqlDbRepository.ReadByApartmentFK)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        while (reader.Read()) {
          yield return Model(reader: reader);
        }
      }
    }

    #endregion

  }
}
