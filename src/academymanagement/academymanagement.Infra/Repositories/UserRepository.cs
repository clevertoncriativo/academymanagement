using academymanagement.Domain.Entities;
using academymanagement.Domain.Interfaces.Repositories;
using academymanagement.Infra.Data;

namespace academymanagement.Infra.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext context)
            : base(context)
        {

        }
    }
}
