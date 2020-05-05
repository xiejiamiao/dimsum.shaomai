using System;
using System.Collections.Generic;
using System.Text;
using Dimsum.Shaomai.DomainEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dimsum.Shaomai.Infrastructure.EntityTypeConfiguration
{
    public class SolutionProjectPropertyTypeConfiguration:IEntityTypeConfiguration<SolutionProjectProperty>
    {
        public void Configure(EntityTypeBuilder<SolutionProjectProperty> builder)
        {
            builder.ToTable("solution_project_property");
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();
            builder.Property(x => x.LastUpdatedOn).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(x => x.SolutionProject).WithMany(x => x.SolutionProjectProperties)
                .HasForeignKey(x => x.SolutionProjectId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Type).HasConversion(v => v.ToString(),
                v => (PropertyType)Enum.Parse(typeof(PropertyType), v));
        }
    }
}
