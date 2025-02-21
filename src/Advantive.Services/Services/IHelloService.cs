using Advantive.Common.Mappers;
using Advantive.Common.Models;
using Advantive.Common.Validators;

namespace Advantive.Services.Services;

public interface IHelloService
{
    Task<ExportProjectResponse> HelloAsync(ExportProjectRequest exportProject);
}

public class HelloService : IHelloService
{
    public Task<ExportProjectResponse> HelloAsync(ExportProjectRequest exportProject)
    {
        exportProject.IsValid();
        return Task.FromResult(exportProject.ToResponse());
    }
}