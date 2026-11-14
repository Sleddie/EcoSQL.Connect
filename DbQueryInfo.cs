using EcoSQL.Request;
using System.ComponentModel.DataAnnotations;

namespace EcoSQL.Connect;

public class DbQueryInfo : QueryInfo, IValidatableObject
{
    public ConnectionInfo? ConnectionInfo { get; set; }

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