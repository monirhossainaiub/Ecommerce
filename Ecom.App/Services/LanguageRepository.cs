using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ApplicationDbContext context;
        public LanguageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Language language)
        {
            context.Languages.Add(language);
            
        }

        public async Task<IEnumerable<Language>> GetAllAsync()
        {
            return await context.Languages
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Language> GetAsync(int id)
        {
            return await context.Languages.FindAsync(id);
        }

        public void Remove(Language language)
        {
            context.Languages.Remove(language);
        }

       public List<string> getName()
        {
            return context.Languages.Select(c => c.Name).ToList();
        }
    }
}
