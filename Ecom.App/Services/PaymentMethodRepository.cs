using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly ApplicationDbContext context;
        public PaymentMethodRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(PaymentMethod paymentMethod)
        {
            context.PaymentMethods.Add(paymentMethod);
            
        }

        public async Task<IEnumerable<PaymentMethod>> GetAllAsync()
        {
            return await context.PaymentMethods
                .OrderBy(os => os.Name)
                .ToListAsync();
        }

        public async Task<PaymentMethod> GetAsync(int id, bool includeRelated = true)
        {

            if(includeRelated == false)
                return await context.PaymentMethods.FindAsync(id);

            return await context.PaymentMethods
                .SingleOrDefaultAsync(pb => pb.Id == id);
        }

        public void Remove(PaymentMethod paymentMethod)
        {
            context.PaymentMethods.Remove(paymentMethod);
        }

       public async Task<List<string>> Names()
        {
            return await context.PaymentMethods.Select(p => p.Name).ToListAsync();
        }
    }
}
