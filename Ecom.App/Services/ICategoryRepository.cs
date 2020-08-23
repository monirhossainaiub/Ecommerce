using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface ICategoryRepository
    {

        Task<Category> GetAsync(int id);
        void Add(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        void Remove(Category category);

        List<string> getCategoryName();

       
    }
}
