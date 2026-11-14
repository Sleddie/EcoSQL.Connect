using EcoSQL.Request;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EcoSQL.Connect;

public class DatabaseInfo : IValidatableObject, IJsonOnDeserialized
{
    protected Dictionary<string, SchemaInfo> _schemas = [];

    public required string Name { get; init; }

    public IReadOnlyDictionary<string, SchemaInfo> Schemas
    {
        get => _schemas.AsReadOnly();
        init => _schemas = new(value);
    }

    public string? DefaultSchemaName { get; init; }
    public SchemaInfo? DefaultSchema { get; protected set; }

    public ServerInfo? Server { get; protected internal set; }

    public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => [];

    public virtual void OnDeserialized()
    {
        foreach (SchemaInfo schema in Schemas.Values)
        {
            schema.Database = this;
        }

        if (string.IsNullOrWhiteSpace(DefaultSchemaName))
            return;

        if (DefaultSchema != Schemas[DefaultSchemaName])
            DefaultSchema = Schemas[DefaultSchemaName];
    }
}