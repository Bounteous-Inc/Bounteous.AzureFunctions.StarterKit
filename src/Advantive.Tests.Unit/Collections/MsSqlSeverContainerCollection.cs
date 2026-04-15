using Bounteous.xUnit.Container.MsSql.Containers;

namespace Advantive.Unit.Tests.Collections;

[CollectionDefinition("MsSqlContainer")]
public class MsSqlContainerCollection : ICollectionFixture<MsSqlServerContainer>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}