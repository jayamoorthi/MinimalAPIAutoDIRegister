using Common.MicroService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Microservice.Infrastructure.EntityConfigurations
{
    public class IdempotencyRequestEntityConfiguration : IEntityTypeConfiguration<IdempotencyRequest>
    {
        public void Configure(EntityTypeBuilder<IdempotencyRequest> builder)
        {
            builder.HasKey(x => x.RequestId);
            builder.Property(x => x.RequestId).IsRequired();
            builder.Property(x=> x.RequestName).IsRequired();
            builder.Property(x=> x.OnCreatedAt).IsRequired();
        }
    }
}
