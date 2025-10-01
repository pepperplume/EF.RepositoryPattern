using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EF.RepositoryPattern
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(params object[] id);
        ValueTask<TEntity> FindAsync(params object[] id);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Add(TEntity entity);
        ValueTask AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void AddRange(params TEntity[] entities);
        Task AddRangeAsync(params TEntity[] entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveRange(params TEntity[] entities);
        void Update(TEntity entity);
        void UpdateRange(TEntity entity);
        void UpdateRange(params TEntity[] entities);
    }
}