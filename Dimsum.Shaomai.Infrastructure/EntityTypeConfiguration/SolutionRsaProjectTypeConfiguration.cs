using System;
using System.Collections.Generic;
using System.Text;
using Dimsum.Shaomai.DomainEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dimsum.Shaomai.Infrastructure.EntityTypeConfiguration
{
    public class SolutionRsaProjectTypeConfiguration:IEntityTypeConfiguration<SolutionRsaProject>
    {
        public void Configure(EntityTypeBuilder<SolutionRsaProject> builder)
        {
            builder.ToTable("solution_rsa_project");
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();
            builder.Property(x => x.LastUpdatedOn).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(x => x.SolutionRsa).WithMany(x => x.SolutionRsaProjects).HasForeignKey(x => x.SolutionRsaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.SolutionProject).WithMany(x => x.SolutionRsaProjects)
                .HasForeignKey(x => x.SolutionProjectId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
