﻿using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface IWriterRepository
    {

        Task<Writer> GetAsync(int id, bool includeRelated = true);
        Task<IEnumerable<Writer>> GetAllAsync();
        void Add(Writer writer);
        void Remove(Writer writer);

        Task<List<string>> Names();

       
    }
}