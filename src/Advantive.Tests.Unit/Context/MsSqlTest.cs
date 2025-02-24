using Advantive.Services.Constants;
using Advantive.Unit.Tests.Containers;
using Bounteous.Core.Validations;

namespace Advantive.Unit.Tests.Context;

[Collection("MsSql Server Collection")]
public class MsSqlTest
{
    private readonly MsSqlContainerFixture msSql;

    public MsSqlTest(MsSqlContainerFixture msSql)
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