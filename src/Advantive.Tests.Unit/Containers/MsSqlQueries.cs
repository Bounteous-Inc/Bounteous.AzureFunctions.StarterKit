using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Advantive.Unit.Tests.Containers;

public static class MsSqlQueries
{
    public static async Task CreateDatabaseIfNotExists(this IDbConnection connection, string databaseName)
    {
        var sql =
            $"""
              IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{databaseName}') 
                BEGIN
                  CREATE DATABASE [{databaseName}]
                END;
            """;
        await connection.ExecuteAsync(sql);
    }

    public static SqlConnection OpenMsSqlConnection(this ISqlContainer container)
    {
        var connection = new SqlConnection(container.ConnectionString);
        connection.Open();
        return connection;
    }
}