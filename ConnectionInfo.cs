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

        //if (User is null
        //    || string.IsNullOrWhiteSpace(User.Name))
        //    yield return new("Empty username.", [nameof(User)]);

        //if (string.IsNullOrWhiteSpace(Password))
        //    yield return new("Empty password.", [nameof(Password)]);

        //if (Database is null)
        //{
        //    yield return new("No database info.", [nameof(Database)]);
        //    yield break;
        //}

        //if (string.IsNullOrWhiteSpace(Database.Name))
        //    yield return new(
        //        "Empty database name.",
        //        [nameof(Database), nameof(Database.Name)]);

        //if (Database.Server is null)
        //{
        //    yield return new(
        //        "No server info.",
        //        [nameof(Database), nameof(Database.Server)]);
        //    yield break;
        //}

        //if (string.IsNullOrWhiteSpace(Database.Server.Host))
        //    yield return new(
        //        "Empty server host.",
        //        [
        //            nameof(Database),
        //            nameof(Database.Server),
        //            nameof(Database.Server.Host)
        //        ]);

        //if (string.IsNullOrWhiteSpace(Database.Server.Port))
        //    yield return new(
        //        "Empty server port.",
        //        [
        //            nameof(Database),
        //            nameof(Database.Server),
        //            nameof(Database.Server.Port)
        //        ]);
    }

    /// <summary>Converts the connection string to a <see cref="ConnectionInfo"/> instance.</summary>
    /// <param name="connectionString">The connection string.</param>
    /// <returns>The <see cref="ConnectionInfo"/> instance.</returns>
    public static implicit operator ConnectionInfo(string connectionString) =>
        new() { ConnectionString = connectionString };
}