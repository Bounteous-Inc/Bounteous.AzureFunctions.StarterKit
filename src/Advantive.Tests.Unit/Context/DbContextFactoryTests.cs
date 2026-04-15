using Advantive.Services;
using Advantive.Services.Constants;
using Advantive.Services.Context;
using Bounteous.Core;
using Bounteous.xUnit.Accelerator.Containers;
using Bounteous.xUnit.Container.MsSql.Containers;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Advantive.Unit.Tests.Context;

[Collection("MsSqlContainer")]
public class DbContextFactoryTests : IClassFixture<MsSqlServerContainer>
{
    private readonly MsSqlServerContainer msSql;
    private IDbContextFactory dbContextFactory; 

    public DbContextFactoryTests(MsSqlServerContainer msSql)
    {
        this.msSql = msSql;
        var collection = new ServiceCollection();
        IoC.ConfigureServiceCollection(collection);
        // Ensure the database is created before resolving the DbContextFactory
        _ = msSql.WithDatabase(Schemas.Advantive).GetAwaiter().GetResult();
        _ = IoC.Resolve<IApplicationConfig>();
    }

    [Fact]
    public void CanConnectToDatabase()
    {
        Log.Debug("CanConnectToDatabase");
        dbContextFactory = IoC.Resolve<IDbContextFactory>();
        using var context = dbContextFactory.Create();
        Assert.True(context.Database.CanConnect(), "Unable to connect to the database.");
    }
}