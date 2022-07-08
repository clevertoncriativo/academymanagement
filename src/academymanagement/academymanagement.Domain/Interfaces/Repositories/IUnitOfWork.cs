using System;
using System.Collections.Generic;
using System.Text;

namespace academymanagement.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        void CommitAsync();
        void RollbackAsync();
    }
}
