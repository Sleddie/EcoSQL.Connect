namespace EcoSQL.Connect;

public record ConnectionInfo(
    string ConnectionString,
    DatabaseInfo Database);