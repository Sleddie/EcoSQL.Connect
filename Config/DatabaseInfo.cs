using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EcoSQL.Connect.Config;

/// <summary>Represents the information about a database.</summary>
public class DatabaseInfo : IValidatableObject, IJsonOnDeserialized
{
    /// <summary>A field to store the database schemas.</summary>
    protected Dictionary<string, SchemaInfo> _schemas = [];

    /// <summary>Gets or sets the name of the database.</summary>
    public required string Name { get; init; }

    /// <summary>Gets or sets the schemas of the database.</summary>
    public IReadOnlyDictionary<string, SchemaInfo> Schemas
    {
        get => _schemas.AsReadOnly();
        init => _schemas = new(value);
    }

    /// <summary>Gets or sets the name of the default schema.</summary>
    public string? DefaultSchemaName { get => DefaultSchema?.Name ?? field; init; }
    /// <summary>Gets or sets the default schema of the database.</summary>
    public SchemaInfo? DefaultSchema { get; set; }

    /// <summary>Gets or sets the server information.</summary>
    public ServerInfo? Server { get; protected internal set; }

    /// <summary>Validates the database information properties.</summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>An enumerable of validation results.</returns>
    public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Name))
            yield return new("Empty database name.", [nameof(Name)]);

        if ((_schemas is null || _schemas.Count == 0)
            && string.IsNullOrWhiteSpace(DefaultSchemaName))
            yield return new("No schemas.", [nameof(Schemas), nameof(DefaultSchemaName)]);

        if (Server is not null)
        {
            foreach (var result in Server.Validate(validationContext))
                yield return result;
        }
        //else
        //{
        //    yield return new("No server info.", [nameof(Server)]);
        //}
    }

    /// <summary>Called when the object is deserialized from JSON.</summary>
    public virtual void OnDeserialized()
    {
        foreach (SchemaInfo schema in Schemas.Values)
        {
            schema.Database = this;
        }

        if (string.IsNullOrWhiteSpace(DefaultSchemaName))
            return;

        DefaultSchema ??= Schemas[DefaultSchemaName];
    }
}
