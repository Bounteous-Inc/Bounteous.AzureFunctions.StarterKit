using Advantive.Unit.Tests.Containers;

namespace Advantive.Unit.Tests.Fixtures;

[CollectionDefinition("MsSql Server Collection")]
public class MsSqlCollection : ICollectionFixture<MsSqlContainerFixture> { }