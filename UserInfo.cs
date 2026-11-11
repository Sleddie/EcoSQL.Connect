namespace EcoSQL.Connect;

public class UserInfo
{
    public required string Name { get; init; }

    public static implicit operator UserInfo(string name) => new() { Name = name };
}