using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Advantive.Unit.Tests.Utilities;

public class TestFunctionsHostBuilder(IServiceCollection services)
    : IFunctionsHostBuilder, IFunctionsConfigurationBuilder
{
    public IServiceCollection Services { get; } = services;

    public IConfiguration Configuration => new ConfigurationBuilder().Build();
    public IConfigurationBuilder ConfigurationBuilder { get; } = null!;
}