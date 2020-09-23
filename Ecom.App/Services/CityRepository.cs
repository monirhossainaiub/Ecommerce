using Ecom.App.Controllers.Resources;
using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext context;
        public CityRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(City city)
        {
            context.Cities.Add(city);
            
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await context.Cities
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<City> GetAsync(int id, bool includeRelated = true)
        {
            return await context.Cities
                .OrderBy(c => c.Name)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public void Remove(City city)
        {
            context.Cities.Remove(city);
        }

       public async Task<List<string>> Names()
        {
            return await context.Cities.Select(p => p.Name).ToListAsync();
        }
    }
}
