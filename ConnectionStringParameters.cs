namespace EcoSQL.Connect;

/// <summary>Represents the information needed to create a database connection string.</summary>
/// <param name="Server">The server name or address.</param>
/// <param name="Database">The database name.</param>
/// <param name="Username">The username for authentication.</param>
/// <param name="Password">The password for authentication.</param>
/// <param name="Timeout">The connection timeout in seconds.</param>
public record ConnectionStringParameters(
    string Server,
    string Database,
    string? Username = null,
    string? Password = null,
    int Timeout = 15);