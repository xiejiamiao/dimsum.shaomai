using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Dimsum.Shaomai.DomainEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dimsum.Shaomai.Infrastructure.EntityTypeConfiguration
{
    public class SolutionEnvTypeConfiguration:IEntityTypeConfiguration<SolutionEnv>
    {
        public void Configure(EntityTypeBuilder<SolutionEnv> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("solution_env");
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.HasIndex(x => new {x.SolutionId, x.EnvName}).IsUnique();
        }
    }
}
