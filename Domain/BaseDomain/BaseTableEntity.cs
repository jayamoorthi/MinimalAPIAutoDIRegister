using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseDomain
{
    public class BaseTableEntity : BaseEntity, IUserInfo
    {

        public BaseTableEntity(Guid id)
        {
            
        }
        private string _createdBy
        {
           get { return _createdBy; }
           set { _createdBy = value; }
        }

        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset ModifiedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
