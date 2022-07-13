using academymanagement.Domain.Commons.Filters;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace academymanagement.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> SaveAsync(T entity);
        void Remove(T entity);
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindAsync(PaginationFilter filter);
    }
}