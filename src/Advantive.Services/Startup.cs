using Bounteous.Core;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Advantive.Services;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddLogging(loggingBuilder =>
            loggingBuilder.AddSerilog());

        IoC.ConfigureServiceCollection(builder.Services);
    }
}