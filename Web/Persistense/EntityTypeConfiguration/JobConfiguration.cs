using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Persistense.EntityTypeConfiguration;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
	public void Configure(EntityTypeBuilder<Job> builder)
	{
		builder.ToTable("jobs");

		builder.Property(j => j.Id)
			.HasColumnName("id")
			.ValueGeneratedOnAdd();

		builder.Property(j => j.Name)
			.HasColumnName("name")
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(j => j.Cron)
			.HasColumnName("cron");

		builder.Property(j => j.WorkflowId)
			.HasColumnName("workflow_id")
			.IsRequired();

		builder.HasOne(j => j.Workflow)
			.WithMany()
			.HasForeignKey(j => j.WorkflowId);
	}
}
