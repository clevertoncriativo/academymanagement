using academymanagement.Domain.Commons.Filters;
using System;

namespace academymanagement.Domain.Interfaces.Services
{
    public interface IUriService
    {
        Uri GetPageUri(PaginationFilter filter, string route);
    }
}
