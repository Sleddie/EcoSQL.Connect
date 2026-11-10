namespace EcoSQL.Connect;

public class SchemaInfo
{
    public required string Name { get; init; }
    public DatabaseInfo? Database { get; protected internal set; }
}