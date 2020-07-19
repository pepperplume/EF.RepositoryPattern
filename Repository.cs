using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public virtual TEntity Find(params object[] id)
        {
            return _Context.Set<TEntity>().Find(id);
        }

       
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate).ToList();
        }

       
        public virtual void Add(TEntity entity)
        {
            _Context.Set<TEntity>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities) Add(entity);
        }

        public virtual void AddRange(params TEntity[] entities)
        {
            AddRange((IEnumerable<TEntity>)entities);
        }

        public virtual void Remove(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities) Remove(entity);
        }

        public virtual void RemoveRange(params TEntity[] entities)
        {
            RemoveRange((IEnumerable<TEntity>)entities);
        }

        public virtual void Update(TEntity entity)
        {
            _Context.Set<TEntity>().Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities) Update(entity);
        }

        public virtual void UpdateRange(params TEntity[] entities)
        {
            UpdateRange((IEnumerable<TEntity>)entities);
        }
    }
}
