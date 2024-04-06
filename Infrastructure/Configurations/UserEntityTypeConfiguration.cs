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
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<LoginUser>  
    {
        public void Configure(EntityTypeBuilder<LoginUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            //// Apply query filter to entity specfic 
           // builder.HasQueryFilter(x => !x.IsSoftDeleted);

            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.IsSoftDeleted).HasDefaultValue(false);

            
        }
    }
}
