using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.Repository.Db.Sql;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.TableModels;

namespace Apartments.DAL.Repository.Db.Sql {
  public class ReservationSqlDbRepository : BaseSqlDbRepository<Int32, ReservationTableModel>, IReservationTableModelRepository {

    #region Constructors

    public ReservationSqlDbRepository(IConnectionStringManager connectionStringManager, ISqlDbTypeManager sqlDbTypeManager)
      : base(connectionStringManager, sqlDbTypeManager) {
    }

    #endregion

    #region Base Overrides

    public override String EntityName => "Reservation";

    public override ReservationTableModel Model(SqlDataReader reader)
      => new ReservationTableModel {
        Id = reader.GetInt32(reader.GetOrdinal(nameof(ReservationTableModel.Id))),
        Guid = reader.GetGuid(reader.GetOrdinal(nameof(ReservationTableModel.Guid))),
        CreateDate = reader.GetDateTime(reader.GetOrdinal(nameof(ReservationTableModel.CreateDate))),
        CreatedBy = reader.GetInt32(reader.GetOrdinal(nameof(ReservationTableModel.CreatedBy))),
        UpdateDate = reader.GetDateTime(reader.GetOrdinal(nameof(ReservationTableModel.UpdateDate))),
        UpdatedBy = reader.GetInt32(reader.GetOrdinal(nameof(ReservationTableModel.UpdatedBy))),
        DeleteDate = !reader.IsDBNull(reader.GetOrdinal(nameof(ReservationTableModel.DeleteDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(ReservationTableModel.DeleteDate)))
          : (DateTime?)null,
        DeletedBy = !reader.IsDBNull(reader.GetOrdinal(nameof(ReservationTableModel.DeletedBy)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(ReservationTableModel.DeletedBy)))
          : (Int32?)null,
        ApartmentFK = reader.GetInt32(reader.GetOrdinal(nameof(ReservationTableModel.ApartmentFK))),
        Details = reader.GetString(reader.GetOrdinal(nameof(ReservationTableModel.Details))),
        UserFK = !reader.IsDBNull(reader.GetOrdinal(nameof(ReservationTableModel.UserFK)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(ReservationTableModel.UserFK)))
          : (Int32?)null,
        UserFName = reader.GetString(reader.GetOrdinal(nameof(ReservationTableModel.UserFName))),
        UserLName = reader.GetString(reader.GetOrdinal(nameof(ReservationTableModel.UserLName))),
        UserEmail = reader.GetString(reader.GetOrdinal(nameof(ReservationTableModel.UserEmail))),
        UserPhoneNumber = reader.GetString(reader.GetOrdinal(nameof(ReservationTableModel.UserPhoneNumber))),
        UserAddress = reader.GetString(reader.GetOrdinal(nameof(ReservationTableModel.UserAddress))),
      };

    public override IList<SqlParameter> Parameterize(ReservationTableModel model)
      => new List<SqlParameter> {
        new SqlParameter { ParameterName = $"@{nameof(ReservationTableModel.ApartmentFK)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReservationTableModel).GetProperty(nameof(ReservationTableModel.ApartmentFK)).PropertyType), Value = model.ApartmentFK },
        new SqlParameter { ParameterName = $"@{nameof(ReservationTableModel.Details)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReservationTableModel).GetProperty(nameof(ReservationTableModel.Details)).PropertyType), Value = model.Details },
        new SqlParameter { ParameterName = $"@{nameof(ReservationTableModel.UserFK)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReservationTableModel).GetProperty(nameof(ReservationTableModel.UserFK)).PropertyType), Value = model.UserFK ?? (Object)DBNull.Value },
        new SqlParameter { ParameterName = $"@{nameof(ReservationTableModel.UserFName)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReservationTableModel).GetProperty(nameof(ReservationTableModel.UserFName)).PropertyType), Value = model.UserFName },
        new SqlParameter { ParameterName = $"@{nameof(ReservationTableModel.UserLName)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReservationTableModel).GetProperty(nameof(ReservationTableModel.UserLName)).PropertyType), Value = model.UserLName },
        new SqlParameter { ParameterName = $"@{nameof(ReservationTableModel.UserEmail)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReservationTableModel).GetProperty(nameof(ReservationTableModel.UserEmail)).PropertyType), Value = model.UserEmail },
        new SqlParameter { ParameterName = $"@{nameof(ReservationTableModel.UserPhoneNumber)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReservationTableModel).GetProperty(nameof(ReservationTableModel.UserPhoneNumber)).PropertyType), Value = model.UserPhoneNumber },
        new SqlParameter { ParameterName = $"@{nameof(ReservationTableModel.UserAddress)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(ReservationTableModel).GetProperty(nameof(ReservationTableModel.UserAddress)).PropertyType), Value = model.UserAddress },
      };

    #endregion

  }
}
