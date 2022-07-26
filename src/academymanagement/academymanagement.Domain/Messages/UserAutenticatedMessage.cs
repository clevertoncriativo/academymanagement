using academymanagement.Domain.Entities;
using System.Collections.Generic;

namespace academymanagement.Domain.Messages
{
    public class UserAutenticatedMessage
    {
        public string Email { get; set; }
        public ICollection<UserRole> Roles { get; set; }
        public string Token { get; set; }
    }
}
