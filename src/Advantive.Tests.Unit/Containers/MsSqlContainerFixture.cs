using Bounteous.Core.Validations;
using Bounteous.Data;
using Dapper;
using Testcontainers.MsSql;

namespace Advantive.Unit.Tests.Containers;

public class MsSqlContainerFixture : ISqlContainer, IAsyncLifetime
{
    public MsSqlContainer Server { get; private set; } = null!;
    public string ConnectionString { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        Server = new MsSqlBuilder()
            .WithPassword("Welcome@123.") // Replace with a strong password
            .Build();
        await Server.StartAsync();
        ConnectionString = Server.GetConnectionString();
    }

    public async Task DisposeAsync()
    {
        if (Server != null)
        {
            await Server.DisposeAsync();
        }
    }

    public async Task<ISqlContainer> WithDatabase(string databaseName)
    {
        Validate.Begin().IsNotEmpty(databaseName, nameof(databaseName)).Check();
        await using var connection = this.OpenMsSqlConnection();
        await connection.CreateDatabaseIfNotExists(databaseName);
        return this;
    }

    public async Task<ISqlContainer> RunSql(string sql)
    {
        await using var connection = this.OpenMsSqlConnection();
        await connection.ExecuteAsync(sql);
        return this;
    }

    public IConnectionStringProvider ConnectionStringProvider { get; } = null!;
}