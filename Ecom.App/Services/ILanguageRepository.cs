using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface ILanguageRepository
    {

        Task<Language> GetAsync(int id);
        void Add(Language language);
        Task<IEnumerable<Language>> GetAllAsync();
        void Remove(Language language);

        List<string> getName();

       
    }
}
