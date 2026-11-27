using EcoSQL.Connect;
using System.Data.Common;

namespace EcoSQL.Dbms;

/// <summary>Represents an interface for database management system provider adapters.</summary>
public interface IDbmsProviderAdapter
{
    /// <summary>Gets the database provider factory.</summary>
    /// <returns>The database provider factory.</returns>
    DbProviderFactory GetDbProviderFactory();

    /// <summary>Gets the provider-specific connection string builder.</summary>
    /// <returns>The provider-specific connection string builder.</returns>
    DbConnectionStringBuilder GetDbConnectionStringBuilder();

    /// <summary>Validates the connection string parameters instance for chosen DBMS provider.</summary>
    /// <param name="connectionStringParameters">The connection string parameters.</param>
    /// <returns>True if the parameters is eligible for the provider; otherwise, false.</returns>
    bool ValidateConnectionStringParameters(ConnectionStringParameters parameters);

    /// <summary>Gets the connection string for the specified connection string parameters.</summary>
    /// <param name="connectionStringParameters">The connection string parameters.</param>
    /// <returns>The connection string.</returns>
    string GetConnectionString(ConnectionStringParameters parameters);
}

/// <summary>Represents an abstract base class for database management system provider adapters.</summary>
public abstract class DbmsProviderAdapter : IDbmsProviderAdapter
{
    /// <inheritdoc/>
    public abstract DbProviderFactory GetDbProviderFactory();

    /// <inheritdoc/>
    public abstract DbConnectionStringBuilder GetDbConnectionStringBuilder();

    /// <inheritdoc/>
    public abstract bool ValidateConnectionStringParameters(ConnectionStringParameters parameters);

    /// <inheritdoc/>
    public abstract string GetConnectionString(ConnectionStringParameters parameters);
}
