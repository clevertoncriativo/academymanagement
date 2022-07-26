using academymanagement.Domain.Entities.Base;

namespace academymanagement.Domain.Entities
{
    public class UserRole : EntityBase
    {
        public string Name { get; set; }
        public User User { get; set; }
    }
}
