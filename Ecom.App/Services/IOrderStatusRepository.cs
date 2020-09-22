using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface IOrderStatusRepository
    {

        Task<OrderStatus> GetAsync(int id, bool includeRelated = true);
        Task<IEnumerable<OrderStatus>> GetAllAsync();
        void Add(OrderStatus orderStatus);
        void Remove(OrderStatus orderStatus);

        Task<List<string>> Names();

       
    }
}
