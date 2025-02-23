using Advantive.Services.Context;
using Advantive.Unit.Tests.Fixtures;
using Bounteous.Core;
using Bounteous.Core.DI;
using Microsoft.Extensions.DependencyInjection;

namespace Advantive.Unit.Tests.Context;

[Collection("Database collection")]
public class DbContextFactoryTests
{
    private readonly SqlServerCollection collection;

    public DbContextFactoryTests(SqlServerCollection collection)
    {
        this.collection = collection;
        var services = new ServiceCollection();
        IoC.ConfigureServiceCollection(services);
        services.ReplaceSingleton(collection.ConnectionStringProvider);
    }

    [Fact]
    public void CanConnectToDatabase()
    {
        var factory = IoC.Resolve<IDbContextFactory>();
        using var context = factory.Create();
        
        Assert.True(context.Database.CanConnect(), "Unable to connect to the database.");
    }
}