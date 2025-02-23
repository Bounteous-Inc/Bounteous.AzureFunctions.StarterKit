using Microsoft.Data.SqlClient;

namespace Advantive.Unit.Tests.Context;

public class DatabaseConnectionTests
{
    private const string ConnectionString =
        "Server=localhost;Database=advantive;User Id=sa;Password=Welcome@123.;TrustServerCertificate=True;";

    [Fact]
    public void CanConnectToDatabase()
    {
        using var connection = new SqlConnection(ConnectionString);
        try
        {
            connection.Open();
            Assert.True(connection.State == System.Data.ConnectionState.Open, "Unable to connect to the database.");
        }
        catch (Exception ex)
        {
            Assert.Fail($"Exception occurred while trying to connect to the database: {ex.Message}");
        }
    }
}