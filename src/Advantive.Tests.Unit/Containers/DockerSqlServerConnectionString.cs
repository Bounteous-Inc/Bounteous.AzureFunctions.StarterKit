using Bounteous.Data;

namespace Advantive.Unit.Tests.Containers;

public class DockerSqlServerConnectionString(string sqlServerConnectionString) : IConnectionStringProvider
{
    public string ConnectionString => sqlServerConnectionString;
}