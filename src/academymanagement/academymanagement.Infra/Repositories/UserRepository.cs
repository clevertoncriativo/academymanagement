using academymanagement.Domain.Entities;
using academymanagement.Domain.Interfaces.Repositories;
using academymanagement.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace academymanagement.Infra.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext context)
            : base(context)
        {

        }

        public async Task<User> FindUser(string email)
        {
            return await _context
                        .Users
                        .Include(i => i.Roles)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(u => u.Email == email 
                                               && u.IsEnabled == true);
        }
    }
}
