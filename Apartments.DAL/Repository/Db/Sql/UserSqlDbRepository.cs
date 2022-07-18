using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.Repository.Db.Sql;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.Enums;

using Apartments.DAL.TableModels;

namespace Apartments.DAL.Repository.Db.Sql {
  public class UserSqlDbRepository : BaseSqlDbRepository<Int32, UserTableModel>, IUserTableModelRepository {

    #region Constructors

    public UserSqlDbRepository(IConnectionStringManager connectionStringManager, ISqlDbTypeManager sqlDbTypeManager)
      : base(connectionStringManager, sqlDbTypeManager) {
    }

    #endregion

    #region Base Overrides

    public override String EntityName => "User";

    public override UserTableModel Model(SqlDataReader reader)
      => new UserTableModel {
        Id = reader.GetInt32(reader.GetOrdinal(nameof(UserTableModel.Id))),
        Guid = reader.GetGuid(reader.GetOrdinal(nameof(UserTableModel.Guid))),
        CreateDate = reader.GetDateTime(reader.GetOrdinal(nameof(UserTableModel.CreateDate))),
        CreatedBy = reader.GetInt32(reader.GetOrdinal(nameof(UserTableModel.CreatedBy))),
        UpdateDate = reader.GetDateTime(reader.GetOrdinal(nameof(UserTableModel.UpdateDate))),
        UpdatedBy = reader.GetInt32(reader.GetOrdinal(nameof(UserTableModel.UpdatedBy))),
        DeleteDate = !reader.IsDBNull(reader.GetOrdinal(nameof(UserTableModel.DeleteDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(UserTableModel.DeleteDate)))
          : (DateTime?)null,
        DeletedBy = !reader.IsDBNull(reader.GetOrdinal(nameof(UserTableModel.DeletedBy)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(UserTableModel.DeletedBy)))
          : (Int32?)null,
        FName = reader.GetString(reader.GetOrdinal(nameof(UserTableModel.FName))),
        LName = reader.GetString(reader.GetOrdinal(nameof(UserTableModel.LName))),
        Username = reader.GetString(reader.GetOrdinal(nameof(UserTableModel.Username))),
        Email = reader.GetString(reader.GetOrdinal(nameof(UserTableModel.Email))),
        PhoneNumber = !reader.IsDBNull(reader.GetOrdinal(nameof(UserTableModel.PhoneNumber)))
          ? reader.GetString(reader.GetOrdinal(nameof(UserTableModel.PhoneNumber)))
          : null,
        PasswordHash = reader.GetString(reader.GetOrdinal(nameof(UserTableModel.PasswordHash))),
        Address = !reader.IsDBNull(reader.GetOrdinal(nameof(UserTableModel.Address)))
          ? reader.GetString(reader.GetOrdinal(nameof(UserTableModel.Address)))
          : null,
        IsAdmin = reader.GetBoolean(reader.GetOrdinal(nameof(UserTableModel.IsAdmin))),
        IsRegistered = reader.GetBoolean(reader.GetOrdinal(nameof(UserTableModel.IsRegistered))),
        RegistrationDate = !reader.IsDBNull(reader.GetOrdinal(nameof(UserTableModel.RegistrationDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(UserTableModel.RegistrationDate)))
          : (DateTime?)null,
        CanResetPassword = reader.GetBoolean(reader.GetOrdinal(nameof(UserTableModel.CanResetPassword))),
        ResetPasswordStartDate = !reader.IsDBNull(reader.GetOrdinal(nameof(UserTableModel.ResetPasswordStartDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(UserTableModel.ResetPasswordStartDate)))
          : (DateTime?)null,
      };

    public override IList<SqlParameter> Parameterize(UserTableModel model)
      => new List<SqlParameter> {
        new SqlParameter { ParameterName = $"@{nameof(UserTableModel.FName)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.FName)).PropertyType), Value = model.FName },
        new SqlParameter { ParameterName = $"@{nameof(UserTableModel.LName)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.LName)).PropertyType), Value = model.LName },
        new SqlParameter { ParameterName = $"@{nameof(UserTableModel.Username)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Username)).PropertyType), Value = model.Username },
        new SqlParameter { ParameterName = $"@{nameof(UserTableModel.Email)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Email)).PropertyType), Value = model.Email },
        new SqlParameter { ParameterName = $"@{nameof(UserTableModel.PhoneNumber)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.PhoneNumber)).PropertyType), Value = model.PhoneNumber },
        new SqlParameter { ParameterName = $"@{nameof(UserTableModel.PasswordHash)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.PasswordHash)).PropertyType), Value = model.PasswordHash },
        new SqlParameter { ParameterName = $"@{nameof(UserTableModel.Address)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Address)).PropertyType), Value = model.Address },
        new SqlParameter { ParameterName = $"@{nameof(UserTableModel.IsAdmin)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.IsAdmin)).PropertyType), Value = model.IsAdmin },
        new SqlParameter { ParameterName = $"@{nameof(UserTableModel.IsRegistered)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.IsRegistered)).PropertyType), Value = model.IsRegistered },
        new SqlParameter { ParameterName = $"@{nameof(UserTableModel.RegistrationDate)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.RegistrationDate)).PropertyType), Value = model.RegistrationDate ?? (Object)DBNull.Value },
        new SqlParameter { ParameterName = $"@{nameof(UserTableModel.CanResetPassword)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.CanResetPassword)).PropertyType), Value = model.CanResetPassword },
        new SqlParameter { ParameterName = $"@{nameof(UserTableModel.ResetPasswordStartDate)}", SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.ResetPasswordStartDate)).PropertyType), Value = model.ResetPasswordStartDate ?? (Object)DBNull.Value },
      };

    #endregion

    #region Public Methods

    #region Login

    public UserTableModel Login(UserTableModel model, String password)
      => Login(username: model.Username, email: model.Email, password: password);
    public UserTableModel Login(String username, String email, String password) {
      IList<SqlParameter> parameters = new List<SqlParameter>
      {
        new SqlParameter {
          ParameterName = "@Username",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Username)).PropertyType),
          Value = username ?? (Object)DBNull.Value,
        },
        new SqlParameter {
          ParameterName = "@Email",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Email)).PropertyType),
          Value = email ?? (Object)DBNull.Value,
        },
        new SqlParameter {
          ParameterName = "@Password",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbType.NVarChar,
          Value = password,
        }
      };

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(UserSqlDbRepository.Login)}]";
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

    #region Registration

    public UserTableModel Register(UserTableModel model, String password, out RegisterStatus registerStatus)
      => Register(model: model, password: password, createdBy: null, registerStatus: out registerStatus);
    public UserTableModel Register(UserTableModel model, String password, Int32? createdBy, out RegisterStatus registerStatus)
      => Register(fName: model.FName, lName: model.LName, username: model.Username, email: model.Email, password: password, isAdmin: model.IsAdmin, createdBy: createdBy, registerStatus: out registerStatus);
    public UserTableModel Register(String fName, String lName, String username, String email, String password, Boolean isAdmin, out RegisterStatus registerStatus)
      => Register(fName: fName, lName: lName, username: username, email: email, password: password, isAdmin: isAdmin, createdBy: null, registerStatus: out registerStatus);
    public UserTableModel Register(String fName, String lName, String username, String email, String password, Boolean isAdmin, Int32? createdBy, out RegisterStatus registerStatus) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@FName",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.FName)).PropertyType),
          Value = fName
        },
        new SqlParameter {
          ParameterName = "@LName",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.LName)).PropertyType),
          Value = lName
        },
        new SqlParameter {
          ParameterName = "@Username",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Username)).PropertyType),
          Value = username
        },
        new SqlParameter {
          ParameterName = "@Email",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Email)).PropertyType),
          Value = email
        },
        new SqlParameter {
          ParameterName = "@Password",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbType.NVarChar,
          Value = password
        },
        new SqlParameter {
          ParameterName = "@IsAdmin",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.IsAdmin)).PropertyType),
          Value = isAdmin
        }
      };

      if (!(createdBy is null)) {
        parameters.Add(new SqlParameter {
          ParameterName = "@CreatedBy",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.CreatedBy)).PropertyType),
          Value = createdBy,
        });
      }

      var returnValue = new SqlParameter {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(UserSqlDbRepository.Register)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        UserTableModel model = reader.Read()
          ? Model(reader: reader)
          : default;

        sqlConnection.Close();

        registerStatus = (RegisterStatus)Enum.Parse(enumType: typeof(RegisterStatus),
                                                    value: returnValue.Value.ToString());
        return model;
      }
    }

    public RegistrationStatus CheckRegistrationStatus(UserTableModel model)
      => CheckRegistrationStatus(guid: model.Guid);
    public RegistrationStatus CheckRegistrationStatus(Guid guid) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@Guid",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Guid)).PropertyType),
          Value = guid,
        }
      };

      var returnValue = new SqlParameter {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(UserSqlDbRepository.CheckRegistrationStatus)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        _ = sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();

        return (RegistrationStatus)Enum.Parse(enumType: typeof(RegistrationStatus),
                                              value: returnValue.Value.ToString());
      }
    }

    public UserTableModel ConfirmRegistration(UserTableModel model, out OperationStatus operationStatus)
      => ConfirmRegistration(guid: model.Guid, operationStatus: out operationStatus);
    public UserTableModel ConfirmRegistration(Guid guid, out OperationStatus operationStatus)
      => ConfirmRegistration(guid: guid, updatedBy: null, operationStatus: out operationStatus);
    public UserTableModel ConfirmRegistration(Guid guid, Int32? updatedBy, out OperationStatus operationStatus) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@Guid",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Guid)).PropertyType),
          Value = guid
        }
      };

      if (!(updatedBy is null)) {
        parameters.Add(new SqlParameter {
          ParameterName = "@UpdatedBy",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.UpdatedBy)).PropertyType),
          Value = updatedBy
        });
      }

      var returnValue = new SqlParameter {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(UserSqlDbRepository.ConfirmRegistration)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        UserTableModel model = reader.Read()
          ? Model(reader: reader)
          : default;

        sqlConnection.Close();

        operationStatus = (OperationStatus)Enum.Parse(enumType: typeof(OperationStatus),
                                                      value: returnValue.Value.ToString());
        return model;
      }
    }

    #endregion

    #region Reset Password

    public UserTableModel RequestResetPassword(UserTableModel model, out RequestResetPasswordStatus requestResetPasswordStatus)
      => RequestResetPassword(email: model.Email, requestResetPasswordStatus: out requestResetPasswordStatus);
    public UserTableModel RequestResetPassword(String email, out RequestResetPasswordStatus requestResetPasswordStatus)
      => RequestResetPassword(email: email, updatedBy: null, requestResetPasswordStatus: out requestResetPasswordStatus);
    public UserTableModel RequestResetPassword(String email, Int32? updatedBy, out RequestResetPasswordStatus requestResetPasswordStatus) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@Email",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Email)).PropertyType),
          Value = email
        }
      };

      if (!(updatedBy is null)) {
        parameters.Add(new SqlParameter {
          ParameterName = "@UpdatedBy",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.UpdatedBy)).PropertyType),
          Value = updatedBy
        });
      }

      var returnValue = new SqlParameter {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(UserSqlDbRepository.RequestResetPassword)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        UserTableModel model = reader.Read()
          ? Model(reader: reader)
          : default;

        sqlConnection.Close();

        requestResetPasswordStatus = (RequestResetPasswordStatus)Enum.Parse(enumType: typeof(RequestResetPasswordStatus),
                                                                            value: returnValue.Value.ToString());
        return model;
      }
    }

    public UserTableModel ReadByEmail(UserTableModel model)
      => ReadByEmail(email: model.Email);
    public UserTableModel ReadByEmail(String email) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@Email",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Email)).PropertyType),
          Value = email
        }
      };

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(UserSqlDbRepository.ReadByEmail)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        return reader.Read()
          ? Model(reader: reader)
          : default;
      }
    }

    public ResetPasswordStatus CheckResetPasswordStatus(UserTableModel model)
      => CheckResetPasswordStatus(guid: model.Guid);
    public ResetPasswordStatus CheckResetPasswordStatus(Guid guid) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@Guid",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Guid)).PropertyType),
          Value = guid,
        }
      };

      var returnValue = new SqlParameter {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(UserSqlDbRepository.CheckResetPasswordStatus)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        _ = sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();

        return (ResetPasswordStatus)Enum.Parse(enumType: typeof(ResetPasswordStatus),
                                               value: returnValue.Value.ToString());
      }
    }

    public UserTableModel ResetPassword(UserTableModel model, String password, out OperationStatus operationStatus)
      => ResetPassword(model: model, password: password, updatedBy: null, operationStatus: out operationStatus);
    public UserTableModel ResetPassword(UserTableModel model, String password, Int32? updatedBy, out OperationStatus operationStatus)
      => ResetPassword(guid: model.Guid, password: password, updatedBy: updatedBy, operationStatus: out operationStatus);
    public UserTableModel ResetPassword(Guid guid, String password, out OperationStatus operationStatus)
      => ResetPassword(guid: guid, password: password, updatedBy: null, operationStatus: out operationStatus);
    public UserTableModel ResetPassword(Guid guid, String password, Int32? updatedBy, out OperationStatus operationStatus) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@Guid",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Guid)).PropertyType),
          Value = guid
        },
        new SqlParameter {
          ParameterName = "@Password",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbType.NVarChar,
          Value = password
        }
      };

      if (!(updatedBy is null)) {
        parameters.Add(new SqlParameter {
          ParameterName = "@UpdatedBy",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.UpdatedBy)).PropertyType),
          Value = updatedBy
        });
      }

      var returnValue = new SqlParameter {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(UserSqlDbRepository.ResetPassword)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        UserTableModel model = reader.Read()
          ? Model(reader: reader)
          : default;

        sqlConnection.Close();

        operationStatus = (OperationStatus)Enum.Parse(enumType: typeof(OperationStatus),
                                                      value: returnValue.Value.ToString());
        return model;
      }
    }

    #endregion

    #region Profile

    public UserTableModel UpdateProfile(UserTableModel model, out OperationStatus operationStatus)
      => UpdateProfile(model: model, updatedBy: null, operationStatus: out operationStatus);
    public UserTableModel UpdateProfile(UserTableModel model, Int32? updatedBy, out OperationStatus operationStatus)
      => UpdateProfile(guid: model.Guid, fName: model.FName, lName: model.LName, phoneNumber: model.PhoneNumber, address: model.Address, updatedBy: updatedBy, operationStatus: out operationStatus);
    public UserTableModel UpdateProfile(Guid guid, String fName, String lName, String phoneNumber, String address, out OperationStatus operationStatus)
      => UpdateProfile(guid: guid, fName: fName, lName: lName, phoneNumber: phoneNumber, address: address, updatedBy: null, operationStatus: out operationStatus);
    public UserTableModel UpdateProfile(Guid guid, String fName, String lName, String phoneNumber, String address, Int32? updatedBy, out OperationStatus operationStatus) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@Guid",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Guid)).PropertyType),
          Value = guid
        },
        new SqlParameter {
          ParameterName = "@FName",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.FName)).PropertyType),
          Value = fName
        },
        new SqlParameter {
          ParameterName = "@LName",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.LName)).PropertyType),
          Value = lName
        },
        new SqlParameter {
          ParameterName = "@PhoneNumber",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.PhoneNumber)).PropertyType),
          Value = phoneNumber
        },
        new SqlParameter {
          ParameterName = "@Address",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.Address)).PropertyType),
          Value = address
        }
      };

      if (!(updatedBy is null)) {
        parameters.Add(new SqlParameter {
          ParameterName = "@UpdatedBy",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(UserTableModel).GetProperty(nameof(UserTableModel.UpdatedBy)).PropertyType),
          Value = updatedBy
        });
      }

      var returnValue = new SqlParameter {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{nameof(UserSqlDbRepository.UpdateProfile)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        UserTableModel model = reader.Read()
          ? Model(reader: reader)
          : default;

        sqlConnection.Close();

        operationStatus = (OperationStatus)Enum.Parse(enumType: typeof(OperationStatus),
                                                      value: returnValue.Value.ToString());
        return model;
      }
    }

    #endregion

    #endregion

  }
}
