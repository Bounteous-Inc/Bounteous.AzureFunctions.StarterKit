using Testcontainers.MsSql;

namespace Advantive.Unit.Tests.Containers;

public class MsSqlContainerFixture : IAsyncLifetime
{
    public MsSqlContainer MsSqlContainer { get; private set; }
    public MsSqlContainer Server => MsSqlContainer;

    public async Task InitializeAsync()
    {
        MsSqlContainer = new MsSqlBuilder()
            .WithPassword("Welcome@123.") // Replace with a strong password
            .Build();

        await MsSqlContainer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await MsSqlContainer.DisposeAsync();
    }
}