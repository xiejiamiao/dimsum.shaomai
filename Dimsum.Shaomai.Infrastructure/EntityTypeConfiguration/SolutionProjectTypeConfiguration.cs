using System;
using System.Collections.Generic;
using System.Text;
using Dimsum.Shaomai.DomainEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dimsum.Shaomai.Infrastructure.EntityTypeConfiguration
{
    public class SolutionProjectTypeConfiguration:IEntityTypeConfiguration<SolutionProject>
    {
        public void Configure(EntityTypeBuilder<SolutionProject> builder)
        {
            builder.ToTable("solution_project");
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.HasIndex(x => new {x.Name, x.SolutionId, x.IsDeleted}).IsUnique();
            builder.HasOne(x => x.Solution).WithMany(x => x.SolutionProjects).HasForeignKey(x => x.SolutionId);
            builder.HasOne(x => x.SolutionEnv).WithMany(x => x.SolutionProjects).HasForeignKey(x => x.SolutionEnvId);
        }
    }
}
