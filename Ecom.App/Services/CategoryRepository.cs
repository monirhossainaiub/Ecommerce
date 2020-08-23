using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Category category)
        {
            context.Categories.Add(category);
            
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await context.Categories.FindAsync(id);
        }

        public void Remove(Category category)
        {
            context.Categories.Remove(category);
        }

       public List<string> getCategoryName()
        {
            return context.Categories.Select(c => c.Name).ToList();
        }
    }
}
