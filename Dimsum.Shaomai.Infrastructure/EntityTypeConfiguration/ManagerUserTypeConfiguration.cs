using System;
using System.Collections.Generic;
using System.Text;
using Dimsum.Shaomai.DomainEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dimsum.Shaomai.Infrastructure.EntityTypeConfiguration
{
    public class ManagerUserTypeConfiguration:IEntityTypeConfiguration<ManagerUser>
    {
        public void Configure(EntityTypeBuilder<ManagerUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("manager_user");
            builder.HasIndex(x => new {x.UserName, x.IsDeleted}).IsUnique();
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
