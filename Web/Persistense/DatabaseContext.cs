using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Persistense;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Workflow> Workflows { get; set; }
	public virtual DbSet<Job> Jobs { get; set; }
}
