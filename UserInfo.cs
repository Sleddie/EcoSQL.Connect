namespace EcoSQL.Connect;

/// <summary>Represents the information about a user.</summary>
public class UserInfo
{
    /// <summary>Gets or sets the name of the user.</summary>
    public required string Name { get; init; }

    /// <summary>Converts the user name to a <see cref="UserInfo"/> instance.</summary>
    /// <param name="name">The user name.</param>
    /// <returns>The <see cref="UserInfo"/> instance.</returns>
    public static implicit operator UserInfo(string name) => new() { Name = name };
}