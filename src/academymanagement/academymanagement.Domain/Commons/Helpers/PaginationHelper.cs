using academymanagement.Domain.Commons.Filters;
using academymanagement.Domain.Interfaces.Services;
using academymanagement.Domain.Messages.Responses;
using System;
using System.Collections.Generic;

namespace academymanagement.Domain.Commons.Helpers
{
    public static class PaginationHelper
    {
        public static PagedResponseMessage<IEnumerable<T>> CreatePagedReponse<T>(List<T> data, PaginationFilter validFilter, int totalRecords, IUriService uriService, string route)
        {
            var result = new PagedResponseMessage<IEnumerable<T>>(data, validFilter.PageNumber, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            
            result.NextPage =
                validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
                : null;

            result.PreviousPage =
                validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
                : null;

            result.FirstPage = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route);
            result.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route);
            result.TotalPages = roundedTotalPages;
            result.TotalRecords = totalRecords;
            
            return result;
        }
    }
}
