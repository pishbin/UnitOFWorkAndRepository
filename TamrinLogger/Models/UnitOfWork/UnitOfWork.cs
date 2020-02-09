using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamrinLogger.Models.Repository;

namespace TamrinLogger.Models.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        public ShopContext _Context { get; }
        private ICategoryRepository _CategooryRepository;
        private IProductRepository _ProductRepository;
        private IDbContextTransaction _transaction;
        public UnitOfWork(ShopContext Context)
        {
            _Context = Context;
            _transaction = _Context.Database.BeginTransaction();
        }

        //public void BeginTransaction()
        //{
        //    _transaction = _Context.Database.BeginTransaction();
        //}
        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity :class
        {
            IBaseRepository<TEntity> repository = new BaseRepository<TEntity, ShopContext>(_Context);
            return repository;
        }

        public ICategoryRepository CategoryRepository
        {
            get { return _CategooryRepository = _CategooryRepository ?? new CategoryRepository(_Context); }
        }

        public IProductRepository ProductRepository
        {
            get { return _ProductRepository = _ProductRepository ?? new ProductsRepository(_Context); }
        }

        public async Task Commit()
        {
            try
            {
                await _Context.SaveChangesAsync();
                  _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }


      
    }
}
