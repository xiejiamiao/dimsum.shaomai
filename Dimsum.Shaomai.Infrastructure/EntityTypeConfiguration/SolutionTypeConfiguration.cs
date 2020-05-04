using System;
using System.Collections.Generic;
using System.Text;
using Dimsum.Shaomai.DomainEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dimsum.Shaomai.Infrastructure.EntityTypeConfiguration
{
    public class SolutionTypeConfiguration:IEntityTypeConfiguration<Solution>
    {
        public void Configure(EntityTypeBuilder<Solution> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("solution");
            builder.HasIndex(x => new {x.Name, x.IsDeleted}).IsUnique();
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.HasOne(x => x.ManagerUser).WithMany(x => x.Solutions).HasForeignKey(x => x.ManagerUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
