using System;
using System.Collections.Generic;
using System.Text;
using Dimsum.Shaomai.DomainEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dimsum.Shaomai.Infrastructure.EntityTypeConfiguration
{
    public class SolutionProcessTypeConfiguration:IEntityTypeConfiguration<SolutionProcess>
    {
        public void Configure(EntityTypeBuilder<SolutionProcess> builder)
        {
            builder.ToTable("solution_process");
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.HasOne(x => x.Solution).WithMany(x => x.SolutionProcesses).HasForeignKey(x => x.SolutionId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Level).HasConversion(v => v.ToString(),
                v => (SolutionProcessLevel) Enum.Parse(typeof(SolutionProcessLevel), v));
        }
    }
}
