using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface ICountryRepository
    {

        Task<Country> GetAsync(int id);
        void Add(Country country);
        Task<IEnumerable<Country>> GetAllAsync();
        void Remove(Country country);

        List<string> getCountryName();

       
    }
}
