using Ecom.App.Controllers.Resources.DTOs;
using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface IBannerRepository
    {

        Task<Banner> GetAsync(int id, bool includeRelated = true);
        Task<IEnumerable<Banner>> GetAllAsync();
        Task<IEnumerable<BannerHomePage>> GetAllActiveAsync();
        Task<IEnumerable<BannerHomePage>> GetAllActiveBannersWithProductsAsync();
        void Add(Banner banner);
        void Remove(Banner banner);

        Task<List<string>> Names();

       
    }
}
