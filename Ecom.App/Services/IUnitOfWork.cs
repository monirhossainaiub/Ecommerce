﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
