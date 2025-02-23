using Bounteous.Data;

namespace Advantive.Unit.Tests.Containers;

public interface ISqlContainer
{
    Task<ISqlContainer> WithDatabase(string schema);
    Task<ISqlContainer>  RunSql(string sql);
    IConnectionStringProvider ConnectionStringProvider { get; }
    string ConnectionString { get; }
}