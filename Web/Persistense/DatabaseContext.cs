using Microsoft.EntityFrameworkCore;
using Persistense.EntityTypeConfiguration;
using Domain;

namespace Persistense;

public partial class DatabaseContext : DbContext
{
	public virtual DbSet<Workflow> Workflows { get; set; }
	public virtual DbSet<Job> Jobs { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new JobConfiguration());
		modelBuilder.ApplyConfiguration(new WorkflowConfiguration());
		base.OnModelCreating(modelBuilder);
	}
}
