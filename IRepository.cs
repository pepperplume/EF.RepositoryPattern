using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EF.RepositoryPattern
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(params object[] id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);
        void AddRange(params TEntity[] entity);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);
        void RemoveRange(params TEntity[] entity);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entity);
        void UpdateRange(params TEntity[] entity);
    }
}