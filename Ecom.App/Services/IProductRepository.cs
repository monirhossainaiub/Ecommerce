using Ecom.App.Controllers.Resources.DTOs;
using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface IProductRepository
    {

        Task<Product> GetAsync(int id, bool includeRelated = true);
        void Add(Product product);
        Task<IEnumerable<ProductViewDto>> GetAllAsync();
        void Remove(Product product);

        List<string> getNames();

       
    }
}
