using Bounteous.Data;

namespace Advantive.Unit.Tests.Containers;

public class ConnectionStringProvider(ISqlContainer container) : IConnectionStringProvider
{
    public string ConnectionString => container.ConnectionString;
}