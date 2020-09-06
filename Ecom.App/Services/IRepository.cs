using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        //void Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllEntityAsync();
        Task<TEntity> GetByIdAsync<TKey>(TKey id);

    }
}
