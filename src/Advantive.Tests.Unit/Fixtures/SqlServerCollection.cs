using Advantive.Services.Constants;
using Advantive.Unit.Tests.Containers;
using Bounteous.Data;

namespace Advantive.Unit.Tests.Fixtures;

[Collection("Database collection")]
public class SqlServerCollection : IDisposable
{
    private readonly DockerSqlServer sqlServer;

    public SqlServerCollection()
    {
        sqlServer = new DockerSqlServer();
        sqlServer.CreateDatabase(Schemas.Advantive);
    }

    public IConnectionStringProvider ConnectionStringProvider
        => new DockerSqlServerConnectionString(sqlServer.ConnectionString);

    public void Dispose() => sqlServer.Dispose();
}