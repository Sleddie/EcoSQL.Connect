using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EcoSQL.Connect.Config;

/// <summary>Represents the information about a schema.</summary>
public class SchemaInfo : IValidatableObject, IJsonOnDeserialized
{
    /// <summary>Gets or sets the name of the schema.</summary>
    public required string Name { get; init; }

    /// <summary>Gets or sets the database information.</summary>
    public DatabaseInfo? Database { get; protected internal set; }

    /// <summary>Validates the schema information properties.</summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>An enumerable of validation results.</returns>
    public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Name))
            yield return new("Empty schema name.", [nameof(Name)]);

        if (Database is not null)
        {
            foreach (var result in Database.Validate(validationContext))
                yield return result;
        }
        //else
        //{
        //    yield return new("No database info.", [nameof(Database)]);
        //}
    }

    /// <summary>Called when the object is deserialized from JSON.</summary>
    public virtual void OnDeserialized() { }
}