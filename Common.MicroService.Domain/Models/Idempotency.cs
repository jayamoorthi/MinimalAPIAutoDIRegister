using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MicroService.Domain.Models
{
    internal interface IIdempotency 
    {
        public Guid RequestId { get; set; }
    }
}
