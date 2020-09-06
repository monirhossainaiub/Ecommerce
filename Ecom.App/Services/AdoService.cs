using AutoMapper;
using Ecom.App.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class AdoService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AdoService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    public  List<T> ReadData<T>(string queryString) where T : class
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;
                context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return mapper.Map<IDataReader, List<T>>(reader);
                    }
                }
            }

            return null;
        }


    }
}
