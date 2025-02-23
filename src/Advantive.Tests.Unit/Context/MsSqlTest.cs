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
    }

    [Fact]
    public void MsSql_Test()
    {
        Validate.Begin().IsNotNull(msSql, nameof(msSql)).Check()
            .IsNotEmpty(msSql.Server.GetConnectionString(), nameof(msSql.Server.GetConnectionString))
            .Check();
    }
}