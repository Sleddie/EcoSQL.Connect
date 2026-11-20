using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace EcoSQL.Connect.Config;

/// <summary>Represents the information about a server.</summary>
public class ServerInfo : IValidatableObject, IJsonOnDeserialized
{
    /// <summary>A field to store the server databases.</summary>
    protected Dictionary<string, DatabaseInfo> _databases = [];

    /// <summary>Gets or sets the name of the server.</summary>
    public string Name
    {
        get => field ??= ToString();
        init;
    }

    /// <summary>Gets or sets the host of the server.</summary>
    public required string Host { get; init; }
    /// <summary>Gets or sets the port of the server.</summary>
    public required string Port { get; init; }

    /// <summary>Gets or sets the databases of the server.</summary>
    public IReadOnlyDictionary<string, DatabaseInfo> Databases
    {
        get => _databases.AsReadOnly();
        init => _databases = new(value);
    }

    /// <summary>Gets or sets the name of the service database.</summary>
    public string? ServiceDatabaseName { get; init; }
    /// <summary>Gets or sets the service database of the server.</summary>
    public DatabaseInfo? ServiceDatabase { get; protected set; }

    /// <summary>Returns a string that represents the server.</summary>
    public override string ToString()
    {
        return $"{Host}:{Port}";
    }

    /// <summary>Validates the server information properties.</summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>An enumerable of validation results.</returns>
    public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        string props = "";
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(Host))
        {
            props = "ip-address";
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(Port))
        {
            if (props != "")
            {
                props += " and ";
            }

            props += "port";
            isValid = false;
        }

        if (!isValid)
            yield return new($"Not specified server {props}.", [nameof(Host), nameof(Port)]);

        if ((_databases is null || _databases.Count == 0) && ServiceDatabase is null)
            yield return new("No databases.", [nameof(Databases), nameof(ServiceDatabase)]);
    }

    /// <summary>Called when the object is deserialized from JSON.</summary>
    public virtual void OnDeserialized()
    {
        foreach (DatabaseInfo database in Databases.Values)
        {
            database.Server = this;
        }

        if (string.IsNullOrWhiteSpace(ServiceDatabaseName))
            return;

        if (ServiceDatabase != Databases[ServiceDatabaseName])
            ServiceDatabase = Databases[ServiceDatabaseName];
    }
}

/// <summary>Compares two <see cref="ServerInfo"/> objects for equality.</summary>
public class ServerInfoComparer : IEqualityComparer<ServerInfo>
{
    /// <summary>Determines whether the specified <see cref="ServerInfo"/> objects are equal.</summary>
    public bool Equals(ServerInfo? x, ServerInfo? y) =>
        string.Equals(x?.ToString(), y?.ToString(), StringComparison.OrdinalIgnoreCase);

    /// <summary>Returns a hash code for the specified <see cref="ServerInfo"/> object.</summary>
    public int GetHashCode([DisallowNull] ServerInfo obj) =>
        obj.ToString().GetHashCode();
}