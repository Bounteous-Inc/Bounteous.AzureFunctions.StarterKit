using Bounteous.Core.Validations;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Testcontainers.MsSql;

namespace Advantive.Unit.Tests.Containers;

public class DockerSqlServer : IDisposable
{
    private readonly Task containerTask;

    public DockerSqlServer()
    {
        var sqlContainer = new MsSqlBuilder().Build();
        containerTask = sqlContainer.StartAsync();
        containerTask.Wait();
        ConnectionString = sqlContainer.GetConnectionString();
    }

    public DockerSqlServer CreateDatabase(string databaseName)
    {
        Validate.Begin().IsNotEmpty(databaseName, nameof(databaseName)).Check();
        ExecuteSql($"CREATE DATABASE [{databaseName}] ON PRIMARY KEY]");
        return this;
    }

    private void ExecuteSql(string sql)
    {
        var serverConnection = new ServerConnection(ConnectionString);
        var server = new Server(serverConnection);
        server.ConnectionContext.ExecuteNonQuery($"CREATE DATABASE [{sql}] ON PRIMARY KEY]");
        server.ConnectionContext.Disconnect();
    }
    
    public string ConnectionString { get; set; }
    
    public void Dispose() => containerTask.Dispose();
}