using Advantive.Services.Constants;
using Advantive.Services.Context;
using Advantive.Unit.Tests.Containers;
using Bounteous.Core;

namespace Advantive.Unit.Tests.Context;

[Collection("MsSql Server Collection")]
public class DbContextFactoryTests
{
    private readonly IDbContextFactory dbContextFactory; 

    public DbContextFactoryTests(MsSqlContainerFixture msSql)
    {
        // Ensure the database is created before resolving the DbContextFactory
        _ = msSql.WithDatabase(Schemas.Advantive).GetAwaiter().GetResult();
        dbContextFactory = IoC.Resolve<IDbContextFactory>();
    }

    [Fact]
    public void CanConnectToDatabase()
    {
        using var context = dbContextFactory.Create();
        Assert.True(context.Database.CanConnect(), "Unable to connect to the database.");
    }
}