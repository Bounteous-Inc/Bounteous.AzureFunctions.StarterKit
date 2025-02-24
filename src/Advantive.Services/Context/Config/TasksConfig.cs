using Advantive.Common.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Advantive.Services.Context.Config;

public class TasksConfig : IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder.ConfigureImmutableBase("tasks");

        builder.Property(t => t.ProjectId)
            .HasColumnName("project_id")
            .IsRequired();

        builder.Property(t => t.TaskName)
            .HasColumnName("task_name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Description)
            .HasColumnName("description")
            .HasMaxLength(255);

        builder.Property(t => t.DueDate)
            .HasColumnName("due_date");

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}