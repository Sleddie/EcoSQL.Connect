using EcoSQL.Connect.Config;
using System.ComponentModel.DataAnnotations;

namespace EcoSQL.Connect;

/// <summary>Represents the information about database connection.</summary>
public class ConnectionInfo : IValidatableObject
{
    /// <summary>Gets or sets the connection string.</summary>
    public required string ConnectionString { get; init; }

    /// <summary>Gets or sets the database information of <see cref="DatabaseInfo"/> type.</summary>
    public DatabaseInfo? Database { get; init; }

    /// <summary>Gets or sets the user information of <see cref="UserInfo"/> type.</summary>
    public UserInfo? User { get; init; }

    /// <summary>Validates the connection information properties.</summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>An enumerable of validation results.</returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(ConnectionString))
            yield return new("Empty connection string.", [nameof(ConnectionString)]);

        if (Database is not null)
        {
            foreach (var result in Database.Validate(validationContext))
                yield return result;
        }
        //else
        //{
        //    yield return new("No database info.", [nameof(Database)]);
        //}

        if (User is not null)
        {
            foreach (var result in User.Validate(validationContext))
                yield return result;
        }
        //else
        //{
        //    yield return new("No user info.", [nameof(User)]);
        //}
    }

    /// <summary>Converts the connection string to a <see cref="ConnectionInfo"/> instance.</summary>
    /// <param name="connectionString">The connection string.</param>
    /// <returns>The <see cref="ConnectionInfo"/> instance.</returns>
    public static implicit operator ConnectionInfo(string connectionString) =>
        new() { ConnectionString = connectionString };
}