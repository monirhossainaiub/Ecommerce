using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface IPaymentMethodRepository
    {

        Task<PaymentMethod> GetAsync(int id, bool includeRelated = true);
        Task<IEnumerable<PaymentMethod>> GetAllAsync();
        void Add(PaymentMethod paymentMethod);
        void Remove(PaymentMethod paymentMethod);

        Task<List<string>> Names();

       
    }
}
