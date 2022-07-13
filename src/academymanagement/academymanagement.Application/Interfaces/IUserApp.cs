using academymanagement.Domain.Commons.Filters;
using academymanagement.Domain.Entities;
using academymanagement.Domain.Messages.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace academymanagement.Application.Interfaces
{
    public interface IUserApp : IBaseApp
    {
        Task<ResponseMessage<User>> SaveAsync(User user);
        Task<ResponseMessage<bool>> DeleteAsync(User user);
        Task<ResponseMessage<User>> FindByIdAsync(int id);
        Task<ResponseMessage<IEnumerable<User>>> FindAsync(PaginationFilter filter);
    }
}
