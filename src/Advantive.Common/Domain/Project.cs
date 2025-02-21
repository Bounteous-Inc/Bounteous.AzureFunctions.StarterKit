using Bounteous.Data.Domain;

namespace Advantive.Common.Domain;

public class Project : AuditImmutableBase
{
    public string ProjectName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}