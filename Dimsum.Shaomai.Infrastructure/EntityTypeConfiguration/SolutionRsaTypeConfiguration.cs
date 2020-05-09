using System;
using System.Collections.Generic;
using System.Text;
using Dimsum.Shaomai.DomainEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dimsum.Shaomai.Infrastructure.EntityTypeConfiguration
{
    public class SolutionRsaTypeConfiguration:IEntityTypeConfiguration<SolutionRsa>
    {
        public void Configure(EntityTypeBuilder<SolutionRsa> builder)
        {
            builder.ToTable("solution_rsa");
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();
            builder.Property(x => x.LastUpdatedOn).ValueGeneratedOnAddOrUpdate();

            builder.Property(x => x.RsaType).HasConversion(v => v.ToString(),
                v => (RsaType)Enum.Parse(typeof(RsaType), v));

            builder.HasOne(x => x.Solution).WithMany(x => x.SolutionRsas).HasForeignKey(x => x.SolutionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
