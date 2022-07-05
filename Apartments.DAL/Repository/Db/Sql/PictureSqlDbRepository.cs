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
  public class PictureSqlDbRepository : BaseSqlDbRepository<Int32, PictureTableModel>, IPictureTableModelRepository {

    #region Constructors

    public PictureSqlDbRepository(IConnectionStringManager connectionStringManager, ISqlDbTypeManager sqlDbTypeManager)
      : base(connectionStringManager, sqlDbTypeManager) {
    }

    #endregion

    #region Base Overrides

    public override String EntityName => "Picture";

    public override PictureTableModel Model(SqlDataReader reader)
      => new PictureTableModel {
        Id = reader.GetInt32(reader.GetOrdinal(nameof(PictureTableModel.Id))),
        Guid = reader.GetGuid(reader.GetOrdinal(nameof(PictureTableModel.Guid))),
        CreateDate = reader.GetDateTime(reader.GetOrdinal(nameof(PictureTableModel.CreateDate))),
        CreatedBy = reader.GetInt32(reader.GetOrdinal(nameof(PictureTableModel.CreatedBy))),
        UpdateDate = reader.GetDateTime(reader.GetOrdinal(nameof(PictureTableModel.UpdateDate))),
        UpdatedBy = reader.GetInt32(reader.GetOrdinal(nameof(PictureTableModel.UpdatedBy))),
        DeleteDate = !reader.IsDBNull(reader.GetOrdinal(nameof(PictureTableModel.DeleteDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(PictureTableModel.DeleteDate)))
          : (DateTime?)null,
        DeletedBy = !reader.IsDBNull(reader.GetOrdinal(nameof(PictureTableModel.DeletedBy)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(PictureTableModel.DeletedBy)))
          : (Int32?)null,
        ApartmentFK = reader.GetInt32(reader.GetOrdinal(nameof(PictureTableModel.ApartmentFK))),
        Title = reader.GetString(reader.GetOrdinal(nameof(PictureTableModel.Title))),
        Path = reader.GetString(reader.GetOrdinal(nameof(PictureTableModel.Path))),
        IsRepresentative = reader.GetBoolean(reader.GetOrdinal(nameof(PictureTableModel.IsRepresentative)))
      };

    public override IList<SqlParameter> Parameterize(PictureTableModel model)
      => new List<SqlParameter> {
        new SqlParameter { ParameterName = $"@{nameof(PictureTableModel.ApartmentFK)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(PictureTableModel).GetProperty(nameof(PictureTableModel.ApartmentFK)).PropertyType), Value = model.ApartmentFK },
        new SqlParameter { ParameterName = $"@{nameof(PictureTableModel.Title)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(PictureTableModel).GetProperty(nameof(PictureTableModel.Title)).PropertyType), Value = model.Title },
        new SqlParameter { ParameterName = $"@{nameof(PictureTableModel.Path)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(PictureTableModel).GetProperty(nameof(PictureTableModel.Path)).PropertyType), Value = model.Path },
        new SqlParameter { ParameterName = $"@{nameof(PictureTableModel.IsRepresentative)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(PictureTableModel).GetProperty(nameof(PictureTableModel.IsRepresentative)).PropertyType), Value = model.IsRepresentative },
      };

    #endregion

    #region Public Methods

    public PictureTableModel ReadRepresentative(Int32 apartmentFK) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@ApartmentFK",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(PictureTableModel).GetProperty(nameof(PictureTableModel.ApartmentFK)).PropertyType),
          Value = apartmentFK
        }
      };

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(PictureSqlDbRepository.ReadRepresentative)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        return reader.Read()
          ? Model(reader: reader)
          : default;
      }
    }

    #endregion

  }
}
