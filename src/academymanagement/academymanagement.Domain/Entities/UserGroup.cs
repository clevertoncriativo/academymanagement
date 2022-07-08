using academymanagement.Domain.Entities.Base;
using System.Collections.Generic;

namespace academymanagement.Domain.Entities
{
    public class UserGroup : EntityBase
    {
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}