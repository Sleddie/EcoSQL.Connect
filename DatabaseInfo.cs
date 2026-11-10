namespace EcoSQL.Connect;

public class DatabaseInfo
{
    public required string Name { get; init; }
    public ServerInfo? Server { get; protected internal set; }
}