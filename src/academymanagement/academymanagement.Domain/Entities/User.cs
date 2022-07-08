using academymanagement.Domain.Entities.Base;

namespace academymanagement.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsEnabled { get; set; } = false;
        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}
