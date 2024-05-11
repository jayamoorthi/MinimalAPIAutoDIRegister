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
    public class IncomingRequestEntityConfiguration : IEntityTypeConfiguration<IncomingRequest>
    {
        public void Configure(EntityTypeBuilder<IncomingRequest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.CorrelationId).IsRequired();
            builder.Property(x => x.EventName).IsRequired();
            builder.Property(x => x.CorrelationId).IsRequired();
            builder.Property(x => x.RequestId).IsRequired();
            builder.Property(x => x.DateTimeCreated).IsRequired();
            builder.Property(x => x.DateTimeUpdated).IsRequired();
        }
    }
}
