using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products
                .OrderBy(c => c.DisplayOrder)
                .ThenBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public void Remove(Product product)
        {
            context.Products.Remove(product);
        }

       public List<string> getNames()
        {
            return context.Products.Select(c => c.Name).ToList();
        }
    }
}
