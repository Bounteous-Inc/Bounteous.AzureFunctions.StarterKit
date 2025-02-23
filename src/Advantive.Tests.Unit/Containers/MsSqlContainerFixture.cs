using Bounteous.Core.Validations;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Testcontainers.MsSql;

namespace Advantive.Unit.Tests.Containers;

public class MsSqlContainerFixture : ISqlContainer, IAsyncLifetime
{
    public MsSqlContainer Server { get; private set; }
    public   string ConnectionString { get; private set; }

    public async Task InitializeAsync()
    {
        Server = new MsSqlBuilder()
            .WithPassword("Welcome@123.") // Replace with a strong password
            .Build();
        await Server.StartAsync();
        ConnectionString = Server.GetConnectionString();
    }

    public async Task DisposeAsync()
        => await Server.DisposeAsync();

    public ISqlContainer WithDatabase(string databaseName)
    {        
        Validate.Begin().IsNotEmpty(databaseName, nameof(databaseName)).Check();
        ExecuteSql($"CREATE DATABASE [{databaseName}]");
        ConnectionString = Server.GetConnectionString().Replace("master", databaseName);
        return this;
    }

    public ISqlContainer RunSql(string sql)
    {
        ExecuteSql(sql);
        return this;
    }
    
    private void ExecuteSql(string sql)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        var command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();
    }
}