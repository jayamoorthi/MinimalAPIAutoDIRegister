using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MicroService.Domain.Models
{
    public class OutGoingIntegrationEvent : IIntegrationEvent
    {
        public Guid Id { get; set; }
        public string EventName { get; set; }
        public string StagingHeader { get; set; }
        public string MessageBody { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset DateTimeUpdated { get; set; }
        public Guid CorrelationId { get; set; }
        public Guid RequestId { get; set; }
        public string TopicName { get; set; }

    }
}
