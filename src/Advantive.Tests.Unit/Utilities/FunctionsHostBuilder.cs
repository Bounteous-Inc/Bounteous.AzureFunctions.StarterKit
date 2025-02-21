using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Advantive.Unit.Tests.Utilities;

public class TestFunctionsHostBuilder : IFunctionsHostBuilder, IFunctionsConfigurationBuilder
{
    public TestFunctionsHostBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; }

    public IConfiguration Configuration => new ConfigurationBuilder().Build();
    public IConfigurationBuilder ConfigurationBuilder { get; }
}