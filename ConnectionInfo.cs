using EcoSQL.Connect.Config;
using EcoSQL.Dbms;
using EcoSQL.Request;
using System.ComponentModel.DataAnnotations;

namespace EcoSQL.Connect;

public class ConnectionInfo : IValidatableObject
{
    public required string ConnectionString { get; init; }

    public DatabaseInfo? Database { get; init; }

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

    internal string GetConnectionString(IMessageUnit? messageUnit = null) =>
        this.IsValid(messageUnit) ? ConnectionString : "";

    public static implicit operator ConnectionInfo(string connectionString) =>
        new() { ConnectionString = connectionString };

    #region obsolete

    [Obsolete($"Use {nameof(ConnectionStringParameters)} to set parameters " +
        $"and {nameof(IDbmsProviderAdapter.GetConnectionString)} method " +
        $"to get the connection string instead.")]
    public const string ConnectionStringFormat =
        ""; //"Host={2}:{3};Database={4};Username={0};Password={1}";

    [Obsolete($"Use {nameof(ConnectionStringParameters)} to set parameters " +
        $"and {nameof(IDbmsProviderAdapter.GetConnectionString)} method " +
        $"to get the connection string instead.")]
    public UserInfo? User { get => null; init { } }

    [Obsolete($"Use {nameof(ConnectionStringParameters)} to set parameters " +
        $"and {nameof(IDbmsProviderAdapter.GetConnectionString)} method " +
        $"to get the connection string instead.")]
    private protected string? Password { get => null; set { } }

    [Obsolete($"Use {nameof(ConnectionStringParameters)} to set parameters " +
        $"and {nameof(IDbmsProviderAdapter.GetConnectionString)} method " +
        $"to get the connection string instead.")]
    public void SetPassword(string password) { }

    #endregion
}