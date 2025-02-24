using Bounteous.Data;

namespace Advantive.Unit.Tests.Containers;

public class ConnectionStringProvider: IConnectionStringProvider
{
    private static string connectionString = string.Empty;

    public static void Configure(string value) => connectionString = value;
    public string ConnectionString => connectionString;
}