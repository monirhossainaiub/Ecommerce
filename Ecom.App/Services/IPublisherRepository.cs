using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface IPublisherRepository
    {

        Task<Publisher> GetAsync(int id, bool includeRelated = true);
        Task<IEnumerable<Publisher>> GetAllAsync();
        void Add(Publisher publisher);
        void Remove(Publisher publisher);

        Task<List<string>> Names();

       
    }
}
