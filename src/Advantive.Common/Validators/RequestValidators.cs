using Advantive.Common.Models;
using Bounteous.Core.Validations;

namespace Advantive.Common.Validators;

public static class RequestValidators
{
    public static void IsValid(this ExportProjectRequest request)
        => Validate.Begin()
            .IsNotNull(request, nameof(request)).Check()
            .IsNotEqual(request.ProjectId, Guid.Empty, "Project Id is invalid")
            .IsNotEmpty(request.Name, "project name is required")
            .Check();

}