using Bounteous.Core.DI;
using Bounteous.Data;
using Bounteous.xUnit.Accelerator.Containers;
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