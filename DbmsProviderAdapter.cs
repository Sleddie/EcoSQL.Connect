using EcoSQL.Connect;
using System.Data.Common;

namespace EcoSQL.Dbms;

/// <summary>Represents an interface for database management system provider adapters.</summary>
public interface IDbmsProviderAdapter
{
    /// <summary>Gets the database provider factory.</summary>
    /// <returns>The database provider factory.</returns>
    DbProviderFactory GetDbProviderFactory();

    /// <summary>Gets the connection string for the specified connection string parameters.</summary>
    /// <param name="connectionStringParameters">The connection string parameters.</param>
    /// <returns>The connection string.</returns>
    string GetConnectionString(ConnectionStringParameters connectionStringParameters);
}

/// <summary>Represents an abstract base class for database management system provider adapters.</summary>
public abstract class DbmsProviderAdapter : IDbmsProviderAdapter
{
    /// <inheritdoc/>
    public abstract DbProviderFactory GetDbProviderFactory();

    /// <inheritdoc/>
    public abstract string GetConnectionString(ConnectionStringParameters connectionStringParameters);
}