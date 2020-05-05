using System;
using System.Collections.Generic;
using System.Text;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Dimsum.Shaomai.Infrastructure
{
    public class DomainContext:DbContext
    {
        public DomainContext(DbContextOptions option) : base(option)
        {
        }

        public DbSet<ManagerUser> ManagerUsers { get; set; }

        public DbSet<Solution> Solutions { get; set; }

        public DbSet<SolutionProject> SolutionProjects { get; set; }

        public DbSet<SolutionEnv> SolutionEnvs { get; set; }

        public DbSet<SolutionProcess> SolutionProcesses { get; set; }

        public DbSet<SolutionProjectProperty> SolutionProjectProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
