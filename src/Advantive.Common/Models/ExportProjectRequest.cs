namespace Advantive.Common.Models;

public class ExportProjectRequest
{
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
}