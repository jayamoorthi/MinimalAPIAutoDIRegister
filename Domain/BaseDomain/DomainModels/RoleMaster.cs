using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseDomain.DomainModels
{
    public class RoleMaster : BaseEntity, ISoftDelete
    {
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool IsSoftDeleted { get; set; }
    }
}
