using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Apartments.DAL.Base.Managers;
using Apartments.DAL.Base.Repository;
using Apartments.DAL.Base.Repository.TableModels;
using Apartments.DAL.Enums;
using Apartments.DAL.TableModels;

namespace Apartments.DAL.Repository.Db.Sql {
  public class MetadataSqlDbRepository : IMetadataTableModelRepository {

    #region Private Properties

    private readonly IConnectionStringManager _connectionStringManager;

    #endregion

    #region Constructors

    public MetadataSqlDbRepository(IConnectionStringManager connectionStringManager) => _connectionStringManager = connectionStringManager;

    #endregion

    #region Private Methods

    private MetadataTableModel Model(SqlDataReader reader)
      => new MetadataTableModel {
        Id = reader.GetInt32(reader.GetOrdinal(nameof(MetadataTableModel.Id))),
        Guid = reader.GetGuid(reader.GetOrdinal(nameof(MetadataTableModel.Guid))),
        CreateDate = reader.GetDateTime(reader.GetOrdinal(nameof(MetadataTableModel.CreateDate))),
        CreatedBy = reader.GetInt32(reader.GetOrdinal(nameof(MetadataTableModel.CreatedBy))),
        UpdateDate = reader.GetDateTime(reader.GetOrdinal(nameof(MetadataTableModel.UpdateDate))),
        UpdatedBy = reader.GetInt32(reader.GetOrdinal(nameof(MetadataTableModel.UpdatedBy))),
        DeleteDate = !reader.IsDBNull(reader.GetOrdinal(nameof(MetadataTableModel.DeleteDate)))
          ? reader.GetDateTime(reader.GetOrdinal(nameof(MetadataTableModel.DeleteDate)))
          : (DateTime?)null,
        DeletedBy = !reader.IsDBNull(reader.GetOrdinal(nameof(MetadataTableModel.DeletedBy)))
          ? reader.GetInt32(reader.GetOrdinal(nameof(MetadataTableModel.DeletedBy)))
          : (Int32?)null,
        Name = reader.GetString(reader.GetOrdinal(nameof(MetadataTableModel.Name))),
        OIB = reader.GetString(reader.GetOrdinal(nameof(MetadataTableModel.OIB))),
        CityFK = reader.GetInt32(reader.GetOrdinal(nameof(MetadataTableModel.CityFK))),
        Address = reader.GetString(reader.GetOrdinal(nameof(MetadataTableModel.Address))),
        Telephone = reader.GetString(reader.GetOrdinal(nameof(MetadataTableModel.Telephone))),
        Mobile = reader.GetString(reader.GetOrdinal(nameof(MetadataTableModel.Mobile))),
        Email = reader.GetString(reader.GetOrdinal(nameof(MetadataTableModel.Email))),
      };

    #endregion

    #region Public Methods

    public MetadataTableModel Read() {
      using (var sqlConnection = new SqlConnection(_connectionStringManager.GetConnectionString())) {
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"[dbo].[Metadata{nameof(MetadataSqlDbRepository.Read)}]";
        sqlCommand.CommandType = CommandType.StoredProcedure;

        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();

        return reader.Read()
          ? Model(reader: reader)
          : throw new InvalidOperationException();
      }
    }

    #endregion

    #region Unimplemented

    public MetadataTableModel Create(MetadataTableModel model, Int32? createdBy, out CreateStatus createStatus) => throw new NotImplementedException();
    public MetadataTableModel Create(MetadataTableModel model, out CreateStatus createStatus) => throw new NotImplementedException();
    public DeleteStatus Delete(Guid guid, Int32? deletedBy) => throw new NotImplementedException();
    public DeleteStatus Delete(Guid guid) => throw new NotImplementedException();
    public DeleteStatus Delete(MetadataTableModel model) => throw new NotImplementedException();
    Enums.UpdateStatus ITableModelRepository<Int32, MetadataTableModel>.Update(Guid guid, MetadataTableModel model, Int32? updatedBy) => throw new NotImplementedException();
    Enums.UpdateStatus IIdentifiableRepository<Int32, MetadataTableModel>.Update(Guid guid, MetadataTableModel model) => throw new NotImplementedException();
    Enums.UpdateStatus IReadWriteRepository<MetadataTableModel>.Update(MetadataTableModel model) => throw new NotImplementedException();
    public IEnumerable<MetadataTableModel> ReadAllAvailable() => throw new NotImplementedException();
    public MetadataTableModel ReadByIdAvailable(Int32 id) => throw new NotImplementedException();
    public MetadataTableModel ReadById(Int32 id) => throw new NotImplementedException();
    public IEnumerable<MetadataTableModel> ReadAll() => throw new NotImplementedException();

    #endregion
  }
}
