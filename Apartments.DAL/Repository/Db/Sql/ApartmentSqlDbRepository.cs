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
  public class ApartmentSqlDbRepository : BaseSqlDbRepository<Int32, ApartmentTableModel>, IApartmentTableModelRepository {

    #region Constructors

    public ApartmentSqlDbRepository(IConnectionStringManager connectionStringManager, ISqlDbTypeManager sqlDbTypeManager)
      : base(connectionStringManager, sqlDbTypeManager) {
    }

    #endregion

    #region Base Overrides

    public override String EntityName => "Apartment";

    public override ApartmentTableModel Model(SqlDataReader reader)
      => new ApartmentTableModel {
        Id = reader.GetInt32(reader.GetOrdinal(nameof(ApartmentTableModel.Id))),
        Guid = reader.GetGuid(reader.GetOrdinal(nameof(ApartmentTableModel.Guid))),
        CreateDate = reader.GetDateTime(reader.GetOrdinal(nameof(ApartmentTableModel.CreateDate))),
        CreatedBy = reader.GetInt32(reader.GetOrdinal(nameof(ApartmentTableModel.CreatedBy))),
        UpdateDate = reader.GetDateTime(reader.GetOrdinal(nameof(ApartmentTableModel.UpdateDate))),
        UpdatedBy = reader.GetInt32(reader.GetOrdinal(nameof(ApartmentTableModel.UpdatedBy))),
        DeleteDate = !reader.IsDBNull(reader.GetOrdinal(nameof(ApartmentTableModel.DeleteDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(ApartmentTableModel.DeleteDate)))
          : (DateTime?)null,
        DeletedBy = !reader.IsDBNull(reader.GetOrdinal(nameof(ApartmentTableModel.DeletedBy)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(ApartmentTableModel.DeletedBy)))
          : (Int32?)null,
        OwnerFK = reader.GetInt32(reader.GetOrdinal(nameof(ApartmentTableModel.OwnerFK))),
        StatusFK = reader.GetInt32(reader.GetOrdinal(nameof(ApartmentTableModel.StatusFK))),
        Name = reader.GetString(reader.GetOrdinal(nameof(ApartmentTableModel.Name))),
        NameEng = reader.GetString(reader.GetOrdinal(nameof(ApartmentTableModel.NameEng))),
        CityFK = reader.GetInt32(reader.GetOrdinal(nameof(ApartmentTableModel.CityFK))),
        Address = reader.GetString(reader.GetOrdinal(nameof(ApartmentTableModel.Address))),
        Price = reader.GetDecimal(reader.GetOrdinal(nameof(ApartmentTableModel.Price))),
        MaxAdults = reader.GetInt32(reader.GetOrdinal(nameof(ApartmentTableModel.MaxAdults))),
        MaxChildren = reader.GetInt32(reader.GetOrdinal(nameof(ApartmentTableModel.MaxChildren))),
        TotalRooms = reader.GetInt32(reader.GetOrdinal(nameof(ApartmentTableModel.TotalRooms))),
        BeachDistance = reader.GetInt32(reader.GetOrdinal(nameof(ApartmentTableModel.BeachDistance)))
      };

    public override IList<SqlParameter> Parameterize(ApartmentTableModel model)
      => new List<SqlParameter> {
        new SqlParameter { ParameterName = $"@{nameof(ApartmentTableModel.OwnerFK)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.OwnerFK)).PropertyType), Value = model.OwnerFK },
        new SqlParameter { ParameterName = $"@{nameof(ApartmentTableModel.StatusFK)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.StatusFK)).PropertyType), Value = model.StatusFK },
        new SqlParameter { ParameterName = $"@{nameof(ApartmentTableModel.Name)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.Name)).PropertyType), Value = model.Name },
        new SqlParameter { ParameterName = $"@{nameof(ApartmentTableModel.NameEng)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.NameEng)).PropertyType), Value = model.NameEng },
        new SqlParameter { ParameterName = $"@{nameof(ApartmentTableModel.CityFK)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.CityFK)).PropertyType), Value = model.CityFK },
        new SqlParameter { ParameterName = $"@{nameof(ApartmentTableModel.Address)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.Address)).PropertyType), Value = model.Address },
        new SqlParameter { ParameterName = $"@{nameof(ApartmentTableModel.Price)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.Price)).PropertyType), Value = model.Price },
        new SqlParameter { ParameterName = $"@{nameof(ApartmentTableModel.MaxAdults)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.MaxAdults)).PropertyType), Value = model.MaxAdults },
        new SqlParameter { ParameterName = $"@{nameof(ApartmentTableModel.MaxChildren)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.MaxChildren)).PropertyType), Value = model.MaxChildren },
        new SqlParameter { ParameterName = $"@{nameof(ApartmentTableModel.TotalRooms)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.TotalRooms)).PropertyType), Value = model.TotalRooms },
        new SqlParameter { ParameterName = $"@{nameof(ApartmentTableModel.BeachDistance)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ApartmentTableModel).GetProperty(nameof(ApartmentTableModel.BeachDistance)).PropertyType), Value = model.BeachDistance },
      };

    #endregion

    #region Public Methods

    public IEnumerable<ApartmentTableModel> ReadByTagFK(Int32 tagFK) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@TagFK",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(TagTableModel).GetProperty(nameof(TagTableModel.Id)).PropertyType),
          Value = tagFK
        }
      };

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(ApartmentSqlDbRepository.ReadByTagFK)}]";
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
