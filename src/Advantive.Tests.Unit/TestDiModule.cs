using Advantive.Unit.Tests.Containers;
using Bounteous.Core.DI;
using Bounteous.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Advantive.Unit.Tests;

public class TestDiModule : IModule
{
    public void RegisterServices(IServiceCollection collection)
    {
        collection.ReplaceSingleton<IConnectionStringProvider>(new ConnectionStringProvider());
    }

    public int Priority { get; } = 1;
}