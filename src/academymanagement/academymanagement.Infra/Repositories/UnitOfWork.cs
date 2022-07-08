using academymanagement.Domain.Interfaces.Repositories;
using academymanagement.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace academymanagement.Infra.Repositories
{
     public class UnitOfWork : IUnitOfWork
    {
        protected readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }

        public void CommitAsync()
        {
            this._context.SaveChangesAsync();
        }

        public void RollbackAsync()
        {

        }
    }
}
