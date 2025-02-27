using Advantive.Services.Constants;
using Bounteous.Core.Validations;
using Bounteous.xUnit.Container.MsSql.Containers;

namespace Advantive.Unit.Tests.Context;

[Collection("MsSqlContainer")]
public class MsSqlTest
{
    private readonly MsSqlServerContainer msSql;

    public MsSqlTest(MsSqlServerContainer msSql)
    {
        this.msSql = msSql;
        // Ensure the database is created before running the test
        _ = msSql.WithDatabase(Schemas.Advantive).GetAwaiter().GetResult();
    }

    [Fact]
    public async Task MsSql_Test()
    {
        Validate.Begin().IsNotNull(msSql, nameof(msSql)).Check()
            .IsNotEmpty(msSql.Server.GetConnectionString(), nameof(msSql.Server.GetConnectionString))
            .Check();
        
        await msSql.RunSql("SELECT SYSDATETIME()");
    }
}