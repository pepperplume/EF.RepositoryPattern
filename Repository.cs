using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EF.RepositoryPattern
{
    public class Repository<TDbContext, TEntity> : IRepository<TEntity> 
        where TDbContext : DbContext
        where TEntity : class, new()
    {
        protected TDbContext _Context { get; private set; }

        public Repository(TDbContext context)
        {
            _Context = context;
        }

        public virtual TEntity Find(params object[] id) => _Context.Set<TEntity>().Find(id);
        public virtual async ValueTask<TEntity> FindAsync(params object[] id) => await _Context.Set<TEntity>().FindAsync(id);

        public virtual IEnumerable<TEntity> GetAll() => _Context.Set<TEntity>().ToList();
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _Context.Set<TEntity>().ToListAsync();

       
        public virtual void Add(TEntity entity) => _Context.Set<TEntity>().Add(entity);
        public virtual async ValueTask AddAsync(TEntity entity) => await _Context.Set<TEntity>().AddAsync(entity);
        public virtual void AddRange(IEnumerable<TEntity> entities) => _Context.Set<TEntity>().AddRange(entities);
        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities) => await _Context.Set<TEntity>().AddRangeAsync(entities);
        public virtual void AddRange(params TEntity[] entities) => _Context.Set<TEntity>().AddRange(entities);
        public virtual async Task AddRangeAsync(params TEntity[] entities) => await _Context.Set<TEntity>().AddRangeAsync(entities);

        public virtual void Remove(TEntity entity) => _Context.Set<TEntity>().Remove(entity);
        public virtual void RemoveRange(IEnumerable<TEntity> entities) => _Context.Set<TEntity>().RemoveRange(entities);
        public virtual void RemoveRange(params TEntity[] entities) => _Context.Set<TEntity>().RemoveRange(entities);

        public virtual void Update(TEntity entity) => _Context.Set<TEntity>().Update(entity);
        public virtual void UpdateRange(TEntity entity) => _Context.Set<TEntity>().UpdateRange(entity);
        public virtual void UpdateRange(params TEntity[] entities) => _Context.Set<TEntity>().UpdateRange(entities);
    }
}
