using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.Repository.Db.Sql;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.Enums;
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
        Data = (Byte[])reader.GetValue(reader.GetOrdinal(nameof(PictureTableModel.Data))),
        MimeType = reader.GetString(reader.GetOrdinal(nameof(PictureTableModel.MimeType))),
        IsRepresentative = reader.GetBoolean(reader.GetOrdinal(nameof(PictureTableModel.IsRepresentative)))
      };

    public override IList<SqlParameter> Parameterize(PictureTableModel model)
      => new List<SqlParameter> {
        new SqlParameter { ParameterName = $"@{nameof(PictureTableModel.ApartmentFK)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(PictureTableModel).GetProperty(nameof(PictureTableModel.ApartmentFK)).PropertyType), Value = model.ApartmentFK },
        new SqlParameter { ParameterName = $"@{nameof(PictureTableModel.Title)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(PictureTableModel).GetProperty(nameof(PictureTableModel.Title)).PropertyType), Value = model.Title },
        new SqlParameter { ParameterName = $"@{nameof(PictureTableModel.Data)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(PictureTableModel).GetProperty(nameof(PictureTableModel.Data)).PropertyType), Value = model.Data },
        new SqlParameter { ParameterName = $"@{nameof(PictureTableModel.MimeType)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(PictureTableModel).GetProperty(nameof(PictureTableModel.MimeType)).PropertyType), Value = model.MimeType },
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

    public IEnumerable<PictureTableModel> ReadByApartmentFK(Int32 apartmentFK) {
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
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(PictureSqlDbRepository.ReadByApartmentFK)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        while (reader.Read()) {
          yield return Model(reader: reader);
        }
      }
    }

    public OperationStatus MakeRepresentative(Guid guid)
      => MakeRepresentative(guid: guid, updatedBy: null);
    public OperationStatus MakeRepresentative(Guid guid, Int32? updatedBy) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@Guid",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(PictureTableModel).GetProperty(nameof(PictureTableModel.Guid)).PropertyType),
          Value = guid
        }
      };

      if (!(updatedBy is null)) {
        parameters.Add(new SqlParameter {
          ParameterName = "@UpdatedBy",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(PictureTableModel).GetProperty(nameof(PictureTableModel.UpdatedBy)).PropertyType),
          Value = updatedBy
        });
      }

      var returnValue = new SqlParameter {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(PictureSqlDbRepository.MakeRepresentative)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        sqlConnection.Close();

        return (OperationStatus)Enum.Parse(enumType: typeof(OperationStatus),
                                           value: returnValue.Value.ToString());
      }
    }

    #endregion

  }
}
