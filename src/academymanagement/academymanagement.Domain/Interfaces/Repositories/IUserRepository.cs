using academymanagement.Domain.Entities;
using System.Threading.Tasks;

namespace academymanagement.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> FindUser(string email);
    }
}
