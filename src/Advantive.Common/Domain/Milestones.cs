using Bounteous.Data.Domain;

namespace Advantive.Common.Domain;

public class Milestones : AuditImmutableBase
{
    public Guid ProjectId { get; set; }
    public string MilestoneName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }

    public Project Project { get; set; } = null!;
}