using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MicroService.Domain.Models
{
    public interface IIntegrationEvent
    {
        public Guid Id { get; set; }
        public string EventName { get; set; }
        public Guid  RequestId { get; set; }
    }
}
