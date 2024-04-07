using Domain.BaseDomain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<RoleMaster>
    {
        public void Configure(EntityTypeBuilder<RoleMaster> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            //// Apply query filter to entity specfic 
            // builder.HasQueryFilter(x => !x.IsSoftDeleted);

            builder.Property(x => x.RoleName).IsRequired();
            builder.Property(x => x.RoleDescription).IsRequired();
            builder.Property(x => x.IsSoftDeleted).HasDefaultValue(false);
            
        }
    }
}
