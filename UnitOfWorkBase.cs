using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF.RepositoryPattern
{
    public class UnitOfWorkBase<TDbContext> : IUnitOfWorkBase where TDbContext : DbContext
    {
        public bool IsDisposed { get; private set; }
        protected TDbContext _Context { get; private set; }

        public UnitOfWorkBase(TDbContext context)
        {
            _Context = context;
            IsDisposed = false;
        }

        public int Complete()
        {
            return _Context.SaveChanges();
        }

        public void Dispose()
        {
            if (IsDisposed) return;

            _Context.Dispose();
            IsDisposed = true;
        }
    }
}
