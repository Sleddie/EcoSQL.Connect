using EcoSQL.Request;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EcoSQL.Connect;

public class SchemaInfo : IValidatableObject, IJsonOnDeserialized
{
    public required string Name { get; init; }

    public DatabaseInfo? Database { get; protected internal set; }

    public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => [];

    public virtual void OnDeserialized() { }
}