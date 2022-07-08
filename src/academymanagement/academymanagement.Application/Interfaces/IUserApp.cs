using academymanagement.Domain.Entities;
using academymanagement.Domain.Messages;
using System.Threading.Tasks;

namespace academymanagement.Application.Interfaces
{
    public interface IUserApp
    {
        Task<ResponseMessage<User>> SaveAsync(User user);
        Task<ResponseMessage<bool>> DeleteAsync(User user);
        Task<ResponseMessage<User>> FindByIdAsync(int id);
    }
}
