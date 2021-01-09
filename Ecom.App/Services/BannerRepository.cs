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

        #region Banner for homepage 
        public async Task<IEnumerable<BannerHomePage>> GetAllActiveAsync()
        {
            return await context.Banners
                .Where(b => b.IsActive == true)
                .Select(b => new BannerHomePage
                {
                    Id = b.Id,
                    Title = b.Title,
                    IsActive = b.IsActive,
                    DisplayOrder = b.DisplayOrder
                })
                .OrderBy(pb => pb.DisplayOrder)
                .ToListAsync();
        }

        public async Task<IEnumerable<BannerHomePage>> GetAllActiveBannersWithProductsAsync(int take)
        {
            var banners = await context.Banners
                .Where(b => b.IsActive == true && b.ProductPublishers.Count != 0)
                .Select(b => new BannerHomePage
                {
                    Id = b.Id,
                    Title = b.Title,
                    IsActive = b.IsActive,
                    DisplayOrder = b.DisplayOrder,
                    Products = b.ProductPublishers
                    .Select(pp => new ProductBannerHomePage
                    {
                        ProductPublisherId = pp.Id,
                        Image = pp.Photos.SingleOrDefault().FileName,
                        ProductName = pp.Product.Name,
                        ProductTitle = pp.Product.Title,
                        StockQuantity = pp.StockQuantity,
                        Price = pp.Price,
                        OldPrice = pp.OldPrice,
                        PublisherId = pp.PublisherId,
                        Publisher = pp.Publisher.Name,
                        WriterId = pp.Product.Writer.Id,
                        Writer = pp.Product.Writer.Name
                    })
                    .Take(take)
                    .ToList()
                })
                .OrderBy(b => b.DisplayOrder)
                .ToListAsync();

            //var results = banners.Where(b => b.IsActive == true && b.Products.Count != 0).ToList();
            return banners;


        }
        #endregion

    }
}
