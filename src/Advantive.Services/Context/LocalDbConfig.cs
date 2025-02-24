namespace Advantive.Services.Context;

public class LocalDbConfig
{
    public string? Host { get; set; } = Environment.GetEnvironmentVariable("LOCAL_DB_HOST") ?? "localhost";
    public string DbName { get; set; } = string.Empty;
    public string DbUser { get; set; } = string.Empty;
    public string DbPassword { get; set; } = string.Empty;

    public string ConnectionString =>
        $"Server={Host};Database={DbName};User Id={DbUser};Password={DbPassword};TrustServerCertificate=True;";
}