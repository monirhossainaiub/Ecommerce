using AutoMapper;
using Ecom.App.Controllers.Resources;
using Ecom.App.Controllers.Resources.DTOs;
using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        //private readonly ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext context,IMapper mapper) : base(context, mapper)
        {
            //this.context = context;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            
        }

       
        public async Task<IEnumerable<ProductViewDto>> GetAllAsync()
        {
            return await context.Products
                .Select(p => new ProductViewDto {
                    Id = p.Id,
                    Name = p.Name,
                    Language = p.Language.Name,
                    Category = p.Category.Name,
                    Writer = p.Writer.Name,
                    DisplayOrder = p.DisplayOrder,
                    Title = p.Title,
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    LanguageId = p.LanguageId,
                    WriterId = p.WriterId,
                    CreatedAt = p.CreatedAt,
                    CreatedBy = p.CreatedBy,
                    UpdatedAt = p.UpdatedAt,
                    UpdatedBy = p.UpdatedBy
                })
                //.Include(p => p.Category)
                //.Include(p => p.Language)
                //.Include(p => p.Writer)
                .OrderBy(c => c.DisplayOrder)
                .ThenBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Product> GetAsync(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Products.FindAsync(id);

            return await context.Products
                .Include(p => p.Category)
                .Include(p => p.Language)
                .Include(p => p.Writer)
                 //.Select(p => new ProductViewDto
                 //{
                 //    Id = p.Id,
                 //    Name = p.Name,
                 //    Language = p.Language.Name,
                 //    Category = p.Category.Name,
                 //    Writer = p.Writer.Name,
                 //    DisplayOrder = p.DisplayOrder,
                 //    Title = p.Title,
                 //    Description = p.Description,
                 //    CategoryId = p.CategoryId,
                 //    LanguageId = p.LanguageId,
                 //    WriterId = p.WriterId,
                 //    CreatedAt = p.CreatedAt,
                 //    CreatedBy = p.CreatedBy,
                 //    UpdatedAt = p.UpdatedAt,
                 //    UpdatedBy = p.UpdatedBy
                 //})
                .OrderBy(p => p.DisplayOrder)
                .ThenBy(p => p.Name)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public void Remove(Product product)
        {
            context.Products.Remove(product);
        }

       public List<string> getNames()
        {
            return context.Products.Select(c => c.Name).ToList();
        }

        public async Task<ProductPublisher> GetProductPublisherAsync(ProductPublisherIds data)
        {
            return await context.ProductPublishers.Where(pp => pp.ProductId == data.ProductId && pp.PublisherId == data.PublisherId).SingleOrDefaultAsync();
        }
        public void AddProductPublisher(ProductPublisher productPublisher)
        {
            context.ProductPublishers.Add(productPublisher);
        }


    }
}
