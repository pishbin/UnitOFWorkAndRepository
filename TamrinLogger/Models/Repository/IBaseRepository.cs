using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamrinLogger.Models.Repository
{
    public interface IBaseRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> FindById(object id);
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Update(TEntity entity);

    }
}
