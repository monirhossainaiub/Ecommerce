using Ecom.App.Controllers.Resources.DTOs;
using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class WriterRepository : IWriterRepository
    {
        private readonly ApplicationDbContext context;
        public WriterRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Writer writer)
        {
            context.Writers.Add(writer);
            
        }

        public async Task<IEnumerable<Writer>> GetAllAsync()
        {
            return await context.Writers
                .OrderBy(w => w.Name)
                .ToListAsync();
        }

        public async Task<Writer> GetAsync(int id, bool includeRelated = true)
        {

            if(includeRelated == false)
                return await context.Writers.FindAsync(id);

            return await context.Writers
                .SingleOrDefaultAsync(pb => pb.Id == id);
        }

        public void Remove(Writer writer)
        {
            context.Writers.Remove(writer);
        }

       public async Task<List<string>> Names()
        {
            return await context.Writers.Select(p => p.Name).ToListAsync();
        }
    }
}
