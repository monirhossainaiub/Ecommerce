using Ecom.App.Controllers.Resources;
using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface ICityRepository
    {

        Task<City> GetAsync(int id, bool includeRelated = true);
        Task<IEnumerable<City>> GetAllAsync();
        void Add(City city);
        void Remove(City city);

        Task<List<string>> Names();

       
    }
}
