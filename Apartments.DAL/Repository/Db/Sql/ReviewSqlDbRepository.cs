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
  public class ReviewSqlDbRepository : BaseSqlDbRepository<Int32, ReviewTableModel>, IReviewTableModelRepository {

    #region Constructors

    public ReviewSqlDbRepository(IConnectionStringManager connectionStringManager, ISqlDbTypeManager sqlDbTypeManager)
      : base(connectionStringManager, sqlDbTypeManager) {
    }

    #endregion

    #region Base Overrides

    public override String EntityName => "Review";

    public override ReviewTableModel Model(SqlDataReader reader)
      => new ReviewTableModel {
        Id = reader.GetInt32(reader.GetOrdinal(nameof(ReviewTableModel.Id))),
        Guid = reader.GetGuid(reader.GetOrdinal(nameof(ReviewTableModel.Guid))),
        CreateDate = reader.GetDateTime(reader.GetOrdinal(nameof(ReviewTableModel.CreateDate))),
        CreatedBy = reader.GetInt32(reader.GetOrdinal(nameof(ReviewTableModel.CreatedBy))),
        UpdateDate = reader.GetDateTime(reader.GetOrdinal(nameof(ReviewTableModel.UpdateDate))),
        UpdatedBy = reader.GetInt32(reader.GetOrdinal(nameof(ReviewTableModel.UpdatedBy))),
        DeleteDate = !reader.IsDBNull(reader.GetOrdinal(nameof(ReviewTableModel.DeleteDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(ReviewTableModel.DeleteDate)))
          : (DateTime?)null,
        DeletedBy = !reader.IsDBNull(reader.GetOrdinal(nameof(ReviewTableModel.DeletedBy)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(ReviewTableModel.DeletedBy)))
          : (Int32?)null,
        ApartmentFK = reader.GetInt32(reader.GetOrdinal(nameof(ReviewTableModel.ApartmentFK))),
        UserFK = reader.GetInt32(reader.GetOrdinal(nameof(ReviewTableModel.UserFK))),
        Details = reader.GetString(reader.GetOrdinal(nameof(ReviewTableModel.Details))),
        Stars = reader.GetInt32(reader.GetOrdinal(nameof(ReviewTableModel.Stars))),
      };

    public override IList<SqlParameter> Parameterize(ReviewTableModel model)
      => new List<SqlParameter> {
        new SqlParameter { ParameterName = $"@{nameof(ReviewTableModel.ApartmentFK)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReviewTableModel).GetProperty(nameof(ReviewTableModel.ApartmentFK)).PropertyType), Value = model.ApartmentFK },
        new SqlParameter { ParameterName = $"@{nameof(ReviewTableModel.UserFK)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReviewTableModel).GetProperty(nameof(ReviewTableModel.UserFK)).PropertyType), Value = model.UserFK },
        new SqlParameter { ParameterName = $"@{nameof(ReviewTableModel.Details)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReviewTableModel).GetProperty(nameof(ReviewTableModel.Details)).PropertyType), Value = model.Details },
        new SqlParameter { ParameterName = $"@{nameof(ReviewTableModel.Stars)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReviewTableModel).GetProperty(nameof(ReviewTableModel.Stars)).PropertyType), Value = model.Stars },
      };

    #endregion

    #region Public Methods

    public IEnumerable<ReviewTableModel> ReadByApartmentFK(Int32 apartmentFK) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@ApartmentFK",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReviewTableModel).GetProperty(nameof(ReviewTableModel.ApartmentFK)).PropertyType),
          Value = apartmentFK
        }
      };

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(ReviewSqlDbRepository.ReadByApartmentFK)}]";
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
