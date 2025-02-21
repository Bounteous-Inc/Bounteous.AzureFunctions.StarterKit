using Advantive.Services;
using Advantive.Services.Services;
using Advantive.Unit.Tests.Utilities;
using Bounteous.Core;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Advantive.Unit.Tests;

public class IocTests
{
    public IocTests()
    {
        var services = new ServiceCollection();
        IoC.ConfigureServiceCollection(services);
        var builder = new TestFunctionsHostBuilder(services);
        new Startup().Configure(builder);
    }
    
    [Fact]
    public void ApplicationConfig() => HasService<IApplicationConfig>();
    
    [Fact]
    public void HelloService() => HasService<IHelloService>();

    private static void HasService<T>() => IoC.Resolve<T>().Should().NotBeNull();
}