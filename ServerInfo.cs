using EcoSQL.Request;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace EcoSQL.Connect;

public class ServerInfo : IValidatableObject, IJsonOnDeserialized
{
    protected Dictionary<string, DatabaseInfo> _databases = [];

    public string Name
    {
        get => field ??= ToString();
        init;
    }
    public required string Host { get; init; }
    public required string Port { get; init; }

    public IReadOnlyDictionary<string, DatabaseInfo> Databases
    {
        get => _databases.AsReadOnly();
        init => _databases = new(value);
    }

    public string? ServiceDatabaseName { get; init; }
    public DatabaseInfo? ServiceDatabase { get; protected set; }

    public override string ToString()
    {
        return $"{Host}:{Port}";
    }

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
            yield return new($"Server {props} should be specified.", [nameof(Host), nameof(Port)]);
    }

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

public class ServerInfoComparer : IEqualityComparer<ServerInfo>
{
    public bool Equals(ServerInfo? x, ServerInfo? y) =>
        string.Equals(x?.ToString(), y?.ToString(), StringComparison.OrdinalIgnoreCase);

    public int GetHashCode([DisallowNull] ServerInfo obj) =>
        obj.ToString().GetHashCode();
}