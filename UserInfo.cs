using System.ComponentModel.DataAnnotations;

namespace EcoSQL.Connect;

/// <summary>Represents the information about a user.</summary>
public class UserInfo : IValidatableObject
{
    /// <summary>Gets or sets the name of the user.</summary>
    public required string Name { get; init; }

    /// <summary>Validates the user information properties.</summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>An enumerable of validation results.</returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Name))
            yield return new("Empty user name.", [nameof(Name)]);
    }

    /// <summary>Converts the user name to a <see cref="UserInfo"/> instance.</summary>
    /// <param name="name">The user name.</param>
    /// <returns>The <see cref="UserInfo"/> instance.</returns>
    public static implicit operator UserInfo(string name) => new() { Name = name };
}