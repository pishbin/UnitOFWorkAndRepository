using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamrinLogger.Models
{
    public class ShopContext:DbContext
    {
        public ShopContext()
        {

        }
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\sql2017;Database=ShopDB;Trusted_Connection=True");
        }
       
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
