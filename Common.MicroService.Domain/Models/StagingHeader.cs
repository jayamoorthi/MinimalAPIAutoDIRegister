using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MicroService.Domain.Models
{
    public class StagingHeader : IIntegrationEvent
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EventName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid RequestId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TopicName { get; set; }
        public string MessageBody { get; set; }
        public Guid HeaderId { get; set; }
        public Guid GroupId { get; set; }
        public int SequenceId { get; set; }
        public Guid CorrelationId { get; set; }
        public string Status { get; set; }
        public string Errors { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeUpdated { get; set; }
        public string Filters { get; set; }
    }
}
