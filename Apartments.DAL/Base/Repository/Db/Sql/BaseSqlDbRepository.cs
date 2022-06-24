using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.TableModels;
using Apartments.DAL.Enums;
using Apartments.DAL.Managers;
using Apartments.DAL.TableModels;

namespace Apartments.DAL.Base.Repository.Db.Sql {
  public abstract class BaseSqlDbRepository<TKey, TModel> : ITableModelRepository<TKey, TModel>, IDbRepository
    where TModel : class, ITableModel<TKey>
    where TKey : struct {

    #region Constants

    private const String CREATE_PROCEDURE_NAME = "Create";

    private const String READ_PROCEDURE_NAME = "Read";

    private const String UPDATE_PROCEDURE_NAME = "Update";

    private const String DELETE_PROCEDURE_NAME = "Delete";

    #endregion

    #region Private Properties

    private readonly IConnectionStringManager _connectionStringManager;

    #endregion

    #region Constructors

    public BaseSqlDbRepository(IConnectionStringManager connectionStringManager, ISqlDbTypeManager sqlDbTypeManager) {
      _connectionStringManager = connectionStringManager;
      SqlDbTypeManager = sqlDbTypeManager;
    }

    #endregion

    #region Protected Properties

    protected ISqlDbTypeManager SqlDbTypeManager { get; }

    #endregion

    #region Public Properties

    public String ConnectionString => _connectionStringManager.ConnectionString;

    #endregion

    #region Abstract

    public abstract String EntityName { get; }

    public abstract TModel Model(SqlDataReader reader);

    public abstract IList<SqlParameter> Parameterize(TModel model);

    #endregion

    #region Create

    public TModel Create(TModel model, out CreateStatus createStatus)
      => Create(model: model, createdBy: null, createStatus: out createStatus);
    public TModel Create(TModel model, TKey? createdBy, out CreateStatus createStatus) {
      IList<SqlParameter> parameters = Parameterize(model);

      parameters.Add(item: new SqlParameter() {
        ParameterName = "@CreatedBy",
        Direction = ParameterDirection.Input,
        SqlDbType = SqlDbTypeManager.GetSqlDbType<TKey>(),
        Value = createdBy ?? (Object)DBNull.Value
      });

      var returnValue = new SqlParameter() {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"EXECUTE [dbo].[{EntityName}{CREATE_PROCEDURE_NAME}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        sqlConnection.Close();

        createStatus = (CreateStatus)Enum.Parse(enumType: typeof(CreateStatus),
                                                  value: returnValue.Value.ToString());

        return reader.Read()
          ? Model(reader: reader)
          : default;
      }
    }

    #endregion

    #region Delete

    public DeleteStatus Delete(TModel model)
      => Delete(guid: model.Guid);
    public DeleteStatus Delete(Guid guid)
      => Delete(guid: guid, deletedBy: null);
    public DeleteStatus Delete(Guid guid, TKey? deletedBy) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter() {
          ParameterName = "@Guid",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbType.UniqueIdentifier,
          Value = guid,
        },
        new SqlParameter() {
          ParameterName = "@DeletedBy",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType<TKey>(),
          Value = deletedBy ?? (Object)DBNull.Value,
        }
      };

      var returnValue = new SqlParameter() {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"EXECUTE [dbo].[{EntityName}{DELETE_PROCEDURE_NAME}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        sqlConnection.Close();

        return (DeleteStatus)Enum.Parse(enumType: typeof(DeleteStatus),
                                        value: returnValue.Value.ToString());
      }
    }

    #endregion

    #region Read

    public IEnumerable<TModel> ReadAll()
      => Read(readMethod: ReadMethod.All, guid: null);
    public IEnumerable<TModel> ReadAllAvailable()
      => Read(readMethod: ReadMethod.AllAvailable, guid: null);
    public TModel ReadByGuid(Guid guid)
      => Read(readMethod: ReadMethod.One, guid: guid).FirstOrDefault();
    public TModel ReadByGuidAvailable(Guid guid)
      => Read(readMethod: ReadMethod.OneAvailable, guid: guid).FirstOrDefault();
    private IEnumerable<TModel> Read(ReadMethod readMethod, Guid? guid) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter
        {
          ParameterName = "@Method",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbType.Int,
          Value = Convert.ToInt32(readMethod),
        },
        new SqlParameter
        {
          ParameterName = "@Guid",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbType.UniqueIdentifier,
          Value = guid ?? (Object)DBNull.Value,
        }
      };

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"EXECUTE [dbo].[{EntityName}{READ_PROCEDURE_NAME}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        sqlConnection.Close();

        while (reader.Read()) {
          yield return Model(reader: reader);
        }
      }
    }

    #endregion

    #region Update

    public Enums.UpdateStatus Update(TModel model)
      => Update(guid: model.Guid, model);
    public Enums.UpdateStatus Update(Guid guid, TModel model)
      => Update(guid: model.Guid, model, updatedBy: null);
    public Enums.UpdateStatus Update(Guid guid, TModel model, TKey? updatedBy) {
      IList<SqlParameter> parameters = Parameterize(model);

      parameters.Add(item: new SqlParameter() {
        ParameterName = "@Guid",
        Direction = ParameterDirection.Input,
        SqlDbType = SqlDbType.UniqueIdentifier,
        Value = guid,
      });

      parameters.Add(item: new SqlParameter() {
        ParameterName = "@UpdatedBy",
        Direction = ParameterDirection.Input,
        SqlDbType = SqlDbTypeManager.GetSqlDbType<TKey>(),
        Value = updatedBy ?? (Object)DBNull.Value,
      });

      var returnValue = new SqlParameter() {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"EXECUTE [dbo].[{EntityName}{UPDATE_PROCEDURE_NAME}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        sqlConnection.Close();

        return (Enums.UpdateStatus)Enum.Parse(enumType: typeof(Enums.UpdateStatus),
                                          value: returnValue.Value.ToString());
      }
    }

    #endregion

  }
}
