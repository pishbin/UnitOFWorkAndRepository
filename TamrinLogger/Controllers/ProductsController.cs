using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TamrinLogger.Models;
using TamrinLogger.Models.UnitOfWork;
using TamrinLogger.Models.ViewModels;

namespace TamrinLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IUnitOfWork _uw;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IUnitOfWork uw, ILogger<ProductsController> logger)
        {
            _uw = uw;
            _logger = logger;

        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var result= await _uw.BaseRepository<Product>().GetAllAsync();

            return result;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _uw.BaseRepository<Product>().FindById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<bool> InsertProduct(ProductsCreateViewModel model)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    var product = new Product()
                    {
                        CategoryID = 2,
                        Count = model.Count,
                        Name = model.Name,
                        Price = model.Price
                    };
                    await _uw.BaseRepository<Product>().CreateAsync(product);
                  await  _uw.Commit();
                    status = true;
                }
            }
            catch (Exception ex)
            {


                status = false;
            }
            return status;
        }
       
      

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
           var product = await _uw.BaseRepository<Product>().FindById(id);
           if (product == null)
            {
                return NotFound("محصولی با این ایدی وجود ندارد");
            }
            _uw.BaseRepository<Product>().Delete(product);
            await _uw.Commit();
           
            return product;
        }



        // PUT: api/Products/5
        [HttpPut]
        public async Task<bool> UpdateProduct(Product product)
        {
            bool status = false;

            try
            {
                var currentProduct = await _uw.BaseRepository<Product>().FindById(product.ProductID);
                if (currentProduct == null)
                    return status;

                _uw.BaseRepository<Product>().Update(product);
                await _uw.Commit();
                _logger.LogInformation($"updated {product.ProductID} Success");
                status = true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError($" Updated {product.ProductID} Faild", ex.Message);
                status = false;
            }

            return status;
        }

    }
}
