using academymanagement.Domain.Entities;
using academymanagement.Domain.Interfaces.Repositories;
using academymanagement.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace academymanagement.Infra.Repositories
{
    public class UserGroupRepository : RepositoryBase<UserGroup>, IUserGroupRepository
    {
        protected readonly DataContext _context;

        public UserGroupRepository(DataContext context)
            : base(context)
        {
            this._context = context;
        }

        public async Task<bool> ExistUserAssociate(int userGroupId)
        {
            return await (_context?.Users?.FirstOrDefaultAsync(u => u.UserGroupId == userGroupId) ?? null) != null;
        }
    }
}
