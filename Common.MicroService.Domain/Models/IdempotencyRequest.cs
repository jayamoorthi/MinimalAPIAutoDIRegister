using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MicroService.Domain.Models
{
    public class IdempotencyRequest
    {
        public Guid RequestId { get; set; }
        public string RequestName { get; set; }
        public DateTimeOffset OnCreatedAt{ get; set; }
    }
}
