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
    public class OutGoingIntegrationEventEntityConfiguration : IEntityTypeConfiguration<OutGoingIntegrationEvent>
    {

        public void Configure(EntityTypeBuilder<OutGoingIntegrationEvent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            //// Apply query filter to entity specfic 
            // builder.HasQueryFilter(x => !x.IsSoftDeleted);

            builder.Property(x => x.CorrelationId).IsRequired();
            builder.Property(x => x.EventName).IsRequired();
            builder.Property(x => x.CorrelationId).IsRequired();
            builder.Property(x => x.MessageBody).IsRequired();
            builder.Property(x => x.StagingHeader).IsRequired();
            builder.Property(x => x.RequestId).IsRequired();
            builder.Property(x => x.StagingHeader).IsRequired();
            builder.Property(x => x.CreatedDateTime).IsRequired();
            builder.Property(x => x.DateTimeUpdated).IsRequired();
            builder.Property(x => x.TopicName).IsRequired();

        }

    }
}
