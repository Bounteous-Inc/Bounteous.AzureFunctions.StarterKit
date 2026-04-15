using Advantive.Common.Mappers;
using Advantive.Common.Models;
using Advantive.Common.Validators;

namespace Advantive.Services.Services;

public interface IExportService
{
    Task<ExportProjectResponse> ExportProjectAsync(ExportProjectRequest exportProject);
}

public class ExportService : IExportService
{
    public Task<ExportProjectResponse> ExportProjectAsync(ExportProjectRequest exportProject)
    {
        exportProject.IsValid();
        return Task.FromResult(exportProject.ToResponse());
    }
}