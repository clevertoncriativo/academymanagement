using academymanagement.Domain.Messages.Responses;
using System.Collections.Generic;

namespace academymanagement.Application.Interfaces
{
    public interface IBaseApp
    {
        ICollection<ResponseError> _responseErrors { get; set; }
    }
}
