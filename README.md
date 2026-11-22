# EcoSQL.Connect

Provides database configuration classes:
- `ServerInfo`;
- `DatabaseInfo`;
- `SchemaInfo`.

Contains:
- `ConnectionStringParameters` class which is used to build the connection string;
- `ConnectionInfo` and `DbQueryInfo` classes;
- `IDbProviderAdapter` interface and `DbProviderAdapter` abstract class as base for DBMS-specific provider implementations (check EcoSQL.Dbms.* projects).

Extends the set of `DbProviderFactory` Select methods.