using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext context;
        public CountryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Country country)
        {
            context.Countries.Add(country);
            
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await context.Countries
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Country> GetAsync(int id)
        {
            return await context.Countries.FindAsync(id);
        }

        public void Remove(Country country)
        {
            context.Countries.Remove(country);
        }

       public List<string> getCountryName()
        {
            return context.Countries.Select(c => c.Name).ToList();
        }
    }
}
