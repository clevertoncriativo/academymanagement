using academymanagement.Domain.Entities;
using academymanagement.Domain.Interfaces.Repositories;
using academymanagement.Infra.Data;

namespace academymanagement.Infra.Repositories
{
    public class UserGroupRepository : RepositoryBase<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(DataContext context)
            : base(context)
        {

        }
    }
}
