using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamrinLogger.Models.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ShopContext _Context;
        public CategoryRepository(ShopContext Context)
        {
            _Context = Context;
        }
    }
}
