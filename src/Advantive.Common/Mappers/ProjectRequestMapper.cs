using Advantive.Common.Models;

namespace Advantive.Common.Mappers;

public static class ProjectRequestMapper
{
    public static ExportProjectResponse ToResponse(this ExportProjectRequest request)
        => new()
        {
            Id = request.ProjectId,
            Name = request.Name,
        };
}