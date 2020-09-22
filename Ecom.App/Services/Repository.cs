using AutoMapper;
using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public Repository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Insert(TEntity entity)
        {
            //context.Entry<TEntity>().State = EntityState.Added;
            context.Set<TEntity>().Add(entity);
        }

        //public void Update(TEntity entity)
        //{
        //    context.Entry<TEntity>(entity).State = EntityState.Modified;
        //}
        public async Task<TEntity> GetByIdAsync<TKey>(TKey id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAllEntityAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }


        public async Task<IEnumerable<T>> ReadData<T>(string queryString) where T : class
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;
                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        return mapper.Map<IDataReader, IEnumerable<T>>(reader);
                    }
                }
            }

            return null;
        }
    }
}
