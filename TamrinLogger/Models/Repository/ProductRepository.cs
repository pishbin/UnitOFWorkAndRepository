using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamrinLogger.Models.Repository
{
    public class ProductsRepository: IProductRepository
    {

        private readonly ShopContext _context;
        public ProductsRepository(ShopContext context)
        {
            _context = context;
        }

    }
}
