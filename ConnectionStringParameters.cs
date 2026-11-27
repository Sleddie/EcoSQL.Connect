namespace EcoSQL.Connect;

/// <summary>Represents the information needed to create a database connection string.</summary>
public class ConnectionStringParameters
{
    /// <summary>A server host or a file URI.</summary>
    public string? DataSource { get; set; }

    /// <summary>A server port.</summary>
    public int? Port { get; set; }

    /// <summary>The database name.</summary>
    public string? Database {  get; set; }

    /// <summary>A user name for authentication.</summary>
    public string? Username { get; set; }

    /// <summary>A password for authentication.</summary>
    public string? Password { get; set; }

    /// <summary>The connection timeout in seconds.</summary>
    public int? Timeout { get; set; }
}
