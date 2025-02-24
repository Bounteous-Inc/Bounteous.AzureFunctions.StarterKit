using Advantive.Services.Context;
using Bounteous.Core;
using Bounteous.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Advantive.Services;

public class AppStartup : IAppStartup
{
    public IConfiguration StartUp(IServiceCollection collection)
    {
        var builder = new ApplicationConfigurationBuilder<ApplicationConfig>();
        var appConfig = builder.Build();

        collection.AddSingleton<IApplicationConfig>(appConfig);
        collection.AddSingleton<IConnectionStringProvider, LocalConnectionStringProvider>();
        collection.AddSingleton<IConnectionBuilder, ConnectionBuilder>();
        collection.AddSingleton<IDbContextFactory, DbContextFactory>();
        collection.AutoRegister(GetType().Assembly);
        
        return builder.Configuration;
    }

    public void InitializeLogging(IConfiguration configuration, Action<IConfiguration> defaultConfig)
        => Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Debug()
            .CreateLogger();
}