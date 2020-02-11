using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamrinLogger.Models.Repository;

namespace TamrinLogger.Models.UnitOfWork
{
  public  interface IUnitOfWork
    {
        //IAuthorRepository AuthorRepository { get; }
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class;
        Task Commit();
        void Rollback();
        //void BeginTransaction();
    }
}
