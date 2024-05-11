using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MicroService.Domain.Models
{
    public class IncomingRequest : IIntegrationEvent
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EventName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid RequestId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid CorrelationId { get; set ; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeUpdated { get; set; }

    }
}
