using EcoSQL.Request;
using System.Data.Common;

namespace EcoSQL.Connect;

public static partial class Select
{
    extension(DbProviderFactory dbProviderFactory)
    {
        /// <summary>Selects a data table from the database.</summary>
        /// <param name="queryInfo">Query information which includes connection details.</param>
        /// <param name="resultTableInfoUnit">Query execution information unit.</param>
        /// <param name="queryAdditionalInfo">Additional query information.</param>
        /// <returns>True if the data table was obtained successfully.</returns>
        public bool SelectDataTable(
            DbQueryInfo queryInfo,
            ResultTableUnit resultTableInfoUnit,
            string? queryAdditionalInfo = null)
        {
            if (!queryInfo.IsValid(resultTableInfoUnit))
                return false;

            return dbProviderFactory.SelectDataTable(
                queryInfo.ConnectionInfo!.GetConnectionString(),
                queryInfo,
                resultTableInfoUnit,
                queryAdditionalInfo);
        }

        /// <summary>Asynchronously selects a data table from the database.</summary>
        /// <param name="queryInfo">Query information which includes connection details.</param>
        /// <param name="resultTableInfoUnit">Query execution information unit.</param>
        /// <param name="queryAdditionalInfo">Additional query information.</param>
        /// <returns>True if the data table was obtained successfully.</returns>
        public async Task<bool> SelectDataTableAsync(
            DbQueryInfo queryInfo,
            ResultTableUnit resultTableInfoUnit,
            string? queryAdditionalInfo = null)
        {
            if (!queryInfo.IsValid(resultTableInfoUnit))
                return false;

            return await dbProviderFactory.SelectDataTableAsync(
                queryInfo.ConnectionInfo!.GetConnectionString(),
                queryInfo,
                resultTableInfoUnit,
                queryAdditionalInfo);
        }

        /// <summary>Selects a collection of items from the database.</summary>
        /// <typeparam name="TItem">Type of items in the collection.</typeparam>
        /// <param name="queryInfo">Query information which includes connection details.</param>
        /// <param name="resultCollectionInfoUnit">Query execution information unit.</param>
        /// <param name="queryAdditionalInfo">Additional query information.</param>
        /// <returns>True if the collection was obtained successfully.</returns>
        public bool SelectCollection<TItem>(
            DbQueryInfo queryInfo,
            ResultCollectionUnit<TItem> resultCollectionInfoUnit,
            string? queryAdditionalInfo = null)
        {
            if (!queryInfo.IsValid(resultCollectionInfoUnit))
                return false;

            return dbProviderFactory.SelectCollection(
                queryInfo.ConnectionInfo!.GetConnectionString(),
                queryInfo,
                resultCollectionInfoUnit,
                queryAdditionalInfo);
        }

        /// <summary>Asynchronously selects a collection of items from the database.</summary>
        /// <typeparam name="TItem">Type of items in the collection.</typeparam>
        /// <param name="queryInfo">Query information which includes connection details.</param>
        /// <param name="resultCollectionInfoUnit">Query execution information unit.</param>
        /// <param name="queryAdditionalInfo">Additional query information.</param>
        /// <returns>True if the collection was obtained successfully.</returns>
        public async Task<bool> SelectCollectionAsync<TItem>(
            DbQueryInfo queryInfo,
            ResultCollectionUnit<TItem> resultCollectionInfoUnit,
            string? queryAdditionalInfo = null)
        {
            if (!queryInfo.IsValid(resultCollectionInfoUnit))
                return false;

            return await dbProviderFactory.SelectCollectionAsync(
                queryInfo.ConnectionInfo!.GetConnectionString(),
                queryInfo,
                resultCollectionInfoUnit,
                queryAdditionalInfo);
        }
    }
}