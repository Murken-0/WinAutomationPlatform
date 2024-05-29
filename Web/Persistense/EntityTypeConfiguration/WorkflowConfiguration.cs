using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Persistense.EntityTypeConfiguration;

public class WorkflowConfiguration : IEntityTypeConfiguration<Workflow>
{
	public void Configure(EntityTypeBuilder<Workflow> builder)
	{
		builder.ToTable("workflows");

		builder.Property(w => w.Id)
			.HasColumnName("id")
			.ValueGeneratedOnAdd();

		builder.Property(w => w.Name)
			.HasColumnName("name")
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(w => w.Version)
			.HasColumnName("version")
			.ValueGeneratedOnAddOrUpdate();

		builder.Property(w => w.LastEdit)
			.HasColumnName("last_edit")
			.ValueGeneratedOnAddOrUpdate();

		builder.Property(w => w.Script)
			.HasColumnName("script");
	}
}
