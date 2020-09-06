using AutoMapper;
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
    public class WriterRepository : Repository<Writer>, IWriterRepository
    {
        public WriterRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
        
        public async Task<IEnumerable<Writer>> GetAllAsync()
        {
            return await context.Writers
                .OrderBy(w => w.Id)
                .ThenBy(w => w.Name)
                .ToListAsync();
            //string sql = $"SELECT * FROM Writers";
            //return await base.ReadData<Writer>(sql);
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
