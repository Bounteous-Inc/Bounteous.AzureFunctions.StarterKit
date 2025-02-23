using Advantive.Services.Context;
using Bounteous.Core;

namespace Advantive.Services;

public interface IApplicationConfig
{
    LocalDbConfig LocalDbConfig { get; set; }
}

public class ApplicationConfig : IApplicationConfig, IApplicationConfigBase
{
    
    public LocalDbConfig LocalDbConfig { get; set; } = null!;
}