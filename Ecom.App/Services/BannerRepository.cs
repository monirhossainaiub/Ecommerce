using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class BannerRepository : IBannerRepository
    {
        private readonly ApplicationDbContext context;
        public BannerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Banner banner)
        {
            context.Banners.Add(banner);
            
        }

        public async Task<IEnumerable<Banner>> GetAllAsync()
        {
            return await context.Banners
                .OrderBy(pb => pb.DisplayOrder)
                .ThenBy(pb => pb.Title)
                .ToListAsync();
        }

        public async Task<Banner> GetAsync(int id, bool includeRelated = true)
        {

            if(includeRelated == false)
                return await context.Banners.FindAsync(id);

            return await context.Banners
                .SingleOrDefaultAsync(pb => pb.Id == id);
        }

        public void Remove(Banner banner)
        {
            context.Banners.Remove(banner);
        }

       public async Task<List<string>> Names()
        {
            return await context.Banners.Select(p => p.Title).ToListAsync();
        }
    }
}
