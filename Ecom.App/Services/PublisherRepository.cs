using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly ApplicationDbContext context;
        public PublisherRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Publisher publisher)
        {
            context.Publishers.Add(publisher);
            
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await context.Publishers
                .OrderBy(pb => pb.DisplayOrder)
                .ThenBy(pb => pb.Name)
                .ToListAsync();
        }

        public async Task<Publisher> GetAsync(int id, bool includeRelated = true)
        {

            if(includeRelated == false)
                return await context.Publishers.FindAsync(id);

            return await context.Publishers
                .SingleOrDefaultAsync(pb => pb.Id == id);
        }

        public void Remove(Publisher publisher)
        {
            context.Publishers.Remove(publisher);
        }

       public async Task<List<string>> Names()
        {
            return await context.Publishers.Select(p => p.Name).ToListAsync();
        }
    }
}
