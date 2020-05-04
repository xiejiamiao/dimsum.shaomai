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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ManagerUserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SolutionTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
