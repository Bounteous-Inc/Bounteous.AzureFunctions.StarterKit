namespace Advantive.Unit.Tests.Containers;

public interface ISqlContainer
{
    ISqlContainer WithDatabase(string schema);
    ISqlContainer RunSql(string sql);
}