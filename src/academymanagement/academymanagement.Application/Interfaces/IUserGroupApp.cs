using academymanagement.Domain.Entities;
using academymanagement.Domain.Messages.Responses;
using System.Threading.Tasks;

namespace academymanagement.Application.Interfaces
{
    public interface IUserGroupApp : IBaseApp
    {
        Task<ResponseMessage<UserGroup>> SaveAsync(UserGroup userGroup);
        Task<ResponseMessage<bool>> DeleteAsync(UserGroup userGroup);
        Task<ResponseMessage<UserGroup>> FindByIdAsync(int id);
    }
}
