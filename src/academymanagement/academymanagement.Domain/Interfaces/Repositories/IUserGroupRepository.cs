using academymanagement.Domain.Entities;
using System.Threading.Tasks;

namespace academymanagement.Domain.Interfaces.Repositories
{
    public interface IUserGroupRepository : IRepositoryBase<UserGroup>
    {
        Task<bool> ExistUserAssociate(int userGroupId);
    }
}
