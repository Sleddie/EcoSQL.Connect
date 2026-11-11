using EcoSQL.Request;
using System.ComponentModel.DataAnnotations;

namespace EcoSQL.Connect;

public class ConnectionInfo : IValidatableObject
{
    public const string ConnectionStringFormat =
        "Host={2}:{3};Database={4};Username={0};Password={1}";

    public required DatabaseInfo Database { get; init; }

    public required UserInfo User { get; init; }

    private protected string? Password { get; set; }

    public void SetPassword(string password) => Password = password;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (User is null
            || string.IsNullOrWhiteSpace(User.Name))
            yield return new ValidationResult("Empty username.", [nameof(User)]);

        if (string.IsNullOrWhiteSpace(Password))
            yield return new ValidationResult("Empty password.", [nameof(Password)]);

        if (Database is null)
        {
            yield return new ValidationResult("No database info.", [nameof(Database)]);
            yield break;
        }

        if (string.IsNullOrWhiteSpace(Database.Name))
            yield return new ValidationResult(
                "Empty database name.",
                [nameof(Database), nameof(Database.Name)]);

        if (Database.Server is null)
        {
            yield return new ValidationResult(
                "No server info.",
                [nameof(Database), nameof(Database.Server)]);
            yield break;
        }

        if (string.IsNullOrWhiteSpace(Database.Server.Host))
            yield return new ValidationResult(
                "Empty server host.",
                [
                    nameof(Database),
                    nameof(Database.Server),
                    nameof(Database.Server.Host)
                ]);

        if (string.IsNullOrWhiteSpace(Database.Server.Port))
            yield return new ValidationResult(
                "Empty server port.",
                [
                    nameof(Database),
                    nameof(Database.Server),
                    nameof(Database.Server.Port)
                ]);
    }

    public bool IsValid(IMessageUnit? messageUnit = null)
    {
        IEnumerable<ValidationResult> errors = Validate(new(this));

        if (errors.Any())
        {
            foreach (var error in errors)
            {
                messageUnit?.Message = error.ErrorMessage;
            }

            return false;
        }

        return true;
    }

    internal string GetConnectionString(IMessageUnit? messageUnit = null)
    {
        if (!IsValid(messageUnit))
            return "";

        return string.Format(
            ConnectionStringFormat,
            User.Name,
            Password,
            Database.Server!.Host,
            Database.Server!.Port,
            Database.Name);
    }
}