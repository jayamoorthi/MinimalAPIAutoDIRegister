using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelDtos
{
    public class UserDto
    {
        public Guid? Id { get; set; } = null;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}
