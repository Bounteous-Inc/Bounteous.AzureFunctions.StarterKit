using Bounteous.Data;

namespace Advantive.Services.Context;

public class LocalConnectionStringProvider(IApplicationConfig config) : IConnectionStringProvider
{
    public string ConnectionString => config.LocalDbConfig.ConnectionString;
}