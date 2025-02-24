using Advantive.Services;
using Advantive.Services.Constants;
using Advantive.Services.Context;
using Advantive.Unit.Tests.Containers;
using Bounteous.Core;
using Bounteous.Core.DI;
using Bounteous.Data;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Advantive.Unit.Tests.Context;

[Collection("MsSql Server Collection")]
public class DbContextFactoryTests
{
    private IDbContextFactory dbContextFactory; 

    public DbContextFactoryTests(MsSqlContainerFixture msSql)
    {
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