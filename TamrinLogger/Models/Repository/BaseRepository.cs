using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamrinLogger.Models.Repository
{
    public class BaseRepository<TEntity,TContext>: IBaseRepository<TEntity> where TEntity : class where TContext :DbContext
    {
        protected TContext _context { get; set; }

        private DbSet<TEntity> _dbSet;
        public BaseRepository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public  async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return  await _dbSet.ToListAsync();
        }

        public async Task<TEntity> FindById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task CreateAsync(TEntity entity)
        {
             await _dbSet.AddAsync(entity);
        }
        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }


    }
}
