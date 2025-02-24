using Advantive.Common.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Advantive.Services.Context.Config;

public class MilestonesConfig: IEntityTypeConfiguration<Milestones>
{
    public void Configure(EntityTypeBuilder<Milestones> builder)
    {
        builder.ConfigureImmutableBase("milestones");

        builder.Property(m => m.MilestoneName)
            .HasColumnName("milestone_name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Description)
            .HasColumnName("description")
            .HasMaxLength(255);

        builder.Property(m => m.DueDate)
            .HasColumnName("due_date");

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(m => m.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}