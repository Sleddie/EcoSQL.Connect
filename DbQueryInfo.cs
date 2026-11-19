using EcoSQL.Request;
using System.ComponentModel.DataAnnotations;

namespace EcoSQL.Connect;

/// <inheritdoc/>
public class DbQueryInfo : QueryInfo, IValidatableObject
{
    /// <summary>Gets or sets the connection information.</summary>
    public required ConnectionInfo ConnectionInfo { get; set; }

    /// <inheritdoc/>
    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        foreach (var validationResult in base.Validate(validationContext))
        {
            yield return validationResult;
        }

        if (ConnectionInfo == null)
        {
            yield return new("No connection info.", [nameof(ConnectionInfo)]);
        }
        else
        {
            foreach (var validationResult in ConnectionInfo.Validate(validationContext))
            {
                yield return validationResult;
            }
        }
    }
}