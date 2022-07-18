using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.TableModels;
using Apartments.DAL.Enums;

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

    #region Overridable

    public abstract String EntityName { get; }

    public virtual TModel Model(SqlDataReader reader)
      => typeof(TModel).GetProperties(bindingAttr: BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                       .Aggregate(seed: Activator.CreateInstance<TModel>(),
                                  func: (obj, property) => {
                                    obj.GetType()
                                       .GetProperty(property.Name)
                                       .SetValue(obj: obj,
                                                 value: !reader.IsDBNull(reader.GetOrdinal(property.Name))
                                                 ? reader.GetValue(reader.GetOrdinal(property.Name))
                                                 : default);
                                    return obj;
                                  });

    public virtual IList<SqlParameter> Parameterize(TModel model)
      => typeof(TModel).GetProperties(bindingAttr: BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                       .Select(selector: property => new SqlParameter {
                         ParameterName = $"@{property.Name}",
                         SqlDbType = !(Nullable.GetUnderlyingType(nullableType: property.PropertyType) is null)
                           ? SqlDbTypeManager.GetSqlDbType(type: Nullable.GetUnderlyingType(nullableType: property.PropertyType))
                           : SqlDbTypeManager.GetSqlDbType(type: property.PropertyType),
                         Value = !(Nullable.GetUnderlyingType(nullableType: property.PropertyType) is null) || !property.PropertyType.IsValueType
                           ? property.GetValue(obj: model) ?? DBNull.Value
                           : property.GetValue(obj: model)
                       })
                       .ToList();

    #endregion

    #region Create

    public virtual TModel Create(TModel model, out CreateStatus createStatus)
      => Create(model: model, createdBy: null, createStatus: out createStatus);
    public virtual TModel Create(TModel model, TKey? createdBy, out CreateStatus createStatus) {
      IList<SqlParameter> parameters = Parameterize(model);

      if (!(createdBy is null)) {
        parameters.Add(item: new SqlParameter {
          ParameterName = "@CreatedBy",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType<TKey>(),
          Value = createdBy
        });
      }

      var returnValue = new SqlParameter {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{CREATE_PROCEDURE_NAME}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        TModel createdModel = reader.Read()
          ? Model(reader: reader)
          : default;

        sqlConnection.Close();

        createStatus = (CreateStatus)Enum.Parse(enumType: typeof(CreateStatus),
                                                  value: returnValue.Value.ToString());
        return createdModel;
      }
    }

    #endregion

    #region Delete

    public virtual DeleteStatus Delete(TModel model)
      => Delete(guid: model.Guid);
    public virtual DeleteStatus Delete(Guid guid)
      => Delete(guid: guid, deletedBy: null);
    public virtual DeleteStatus Delete(Guid guid, TKey? deletedBy) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@Guid",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbType.UniqueIdentifier,
          Value = guid,
        }
      };

      if (!(deletedBy is null)) {
        parameters.Add(new SqlParameter() {
          ParameterName = "@DeletedBy",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType<TKey>(),
          Value = deletedBy
        });
      }

      var returnValue = new SqlParameter() {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{DELETE_PROCEDURE_NAME}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        _ = sqlCommand.ExecuteNonQuery();

        return (DeleteStatus)Enum.Parse(enumType: typeof(DeleteStatus),
                                        value: returnValue.Value.ToString());
      }
    }

    #endregion

    #region Read

    public virtual IEnumerable<TModel> ReadAll()
      => Read(readMethod: ReadMethod.All, id: null);
    public virtual IEnumerable<TModel> ReadAllAvailable()
      => Read(readMethod: ReadMethod.AllAvailable, id: null);
    public virtual TModel ReadById(TKey id)
      => Read(readMethod: ReadMethod.One, id: id).FirstOrDefault();
    public virtual TModel ReadByIdAvailable(TKey id)
      => Read(readMethod: ReadMethod.OneAvailable, id: id).FirstOrDefault();
    private IEnumerable<TModel> Read(ReadMethod readMethod, TKey? id) {
      IList<SqlParameter> parameters = new List<SqlParameter> {
        new SqlParameter {
          ParameterName = "@Method",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbType.Int,
          Value = Convert.ToInt32(readMethod),
        }
      };

      if (!(id is null)) {
        parameters.Add(new SqlParameter {
          ParameterName = "@Id",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType(typeof(TKey)),
          Value = id
        });
      }

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{READ_PROCEDURE_NAME}]";
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

    #region Update

    public virtual Enums.UpdateStatus Update(TModel model)
      => Update(guid: model.Guid, model);
    public virtual Enums.UpdateStatus Update(Guid guid, TModel model)
      => Update(guid: model.Guid, model, updatedBy: null);
    public virtual Enums.UpdateStatus Update(Guid guid, TModel model, TKey? updatedBy) {
      IList<SqlParameter> parameters = Parameterize(model);

      parameters.Add(item: new SqlParameter {
        ParameterName = "@Guid",
        Direction = ParameterDirection.Input,
        SqlDbType = SqlDbType.UniqueIdentifier,
        Value = guid,
      });

      if (!(updatedBy is null)) {
        parameters.Add(item: new SqlParameter {
          ParameterName = "@UpdatedBy",
          Direction = ParameterDirection.Input,
          SqlDbType = SqlDbTypeManager.GetSqlDbType<TKey>(),
          Value = updatedBy
        });
      }

      var returnValue = new SqlParameter {
        Direction = ParameterDirection.ReturnValue
      };
      parameters.Add(item: returnValue);

      using (var sqlConnection = new SqlConnection(ConnectionString)) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[{EntityName}{UPDATE_PROCEDURE_NAME}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddRange(values: parameters.ToArray());

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        return (Enums.UpdateStatus)Enum.Parse(enumType: typeof(Enums.UpdateStatus),
                                          value: returnValue.Value.ToString());
      }
    }

    #endregion

  }
}
