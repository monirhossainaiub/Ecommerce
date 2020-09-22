using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly ApplicationDbContext context;
        public OrderStatusRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(OrderStatus orderStatus)
        {
            context.OrderStatus.Add(orderStatus);
            
        }

        public async Task<IEnumerable<OrderStatus>> GetAllAsync()
        {
            return await context.OrderStatus
                .OrderBy(os => os.Name)
                .ToListAsync();
        }

        public async Task<OrderStatus> GetAsync(int id, bool includeRelated = true)
        {

            if(includeRelated == false)
                return await context.OrderStatus.FindAsync(id);

            return await context.OrderStatus
                .SingleOrDefaultAsync(pb => pb.Id == id);
        }

        public void Remove(OrderStatus orderStatus)
        {
            context.OrderStatus.Remove(orderStatus);
        }

       public async Task<List<string>> Names()
        {
            return await context.OrderStatus.Select(p => p.Name).ToListAsync();
        }
    }
}
