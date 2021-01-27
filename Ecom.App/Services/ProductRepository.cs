using AutoMapper;
using AutoMapper.DataReaderMapper;
using Ecom.App.Controllers.Resources;
using Ecom.App.Controllers.Resources.DTOs;
using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductRepository(ApplicationDbContext context,IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
        }
        
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products
                .Include(p => p.Category)
                .Include(p => p.Writer)
                .Include(p => p.ProductPublishers)
                    .ThenInclude(pp => pp.Publisher)
                .Include(p => p.ProductPublishers)
                    .ThenInclude(pp => pp.Photos)
                .ToListAsync();


            //return await context.Products
            //    .Select(p => new ProductViewDto
            //    {
            //        Id = p.Id,
            //        Name = p.Name,
            //        DisplayOrder = p.DisplayOrder,
            //        Title = p.Title,
            //        Description = p.Description,
            //        Language = p.Language.Name,
            //        Category = p.Category.Name,
            //        Writer = p.Writer.Name,
            //        CategoryId = p.CategoryId,
            //        LanguageId = p.LanguageId,
            //        WriterId = p.WriterId,
            //        CreatedAt = p.CreatedAt,
            //        CreatedBy = p.CreatedBy,
            //        UpdatedAt = p.UpdatedAt,
            //        UpdatedBy = p.UpdatedBy,
            //        Publisher = p.ProductPublishers.Select(pp => pp.Publisher.Name).SingleOrDefault()
            //    })
            //    .OrderBy(c => c.DisplayOrder)
            //    .ThenBy(c => c.Name)
            //    .ToListAsync();
        }

        public async Task<Product> GetAsync(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Products.FindAsync(id);

            return await context.Products
                .Include(p => p.Category)
                .Include(p => p.Writer)
                .OrderBy(p => p.DisplayOrder)
                .ThenBy(p => p.Name)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductDetailDto> GetProductDetaisAsync(int id)
        {
            ProductDetailDto product = new ProductDetailDto();
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                string queryString = @"SELECT pp.Id, 
                                    p.Name, 
                                    pp.StockQuantity as Quantity, 
                                    pp.Price, 
                                    pp.OldPrice, 
                                    l.Id as LanguageId,
                                    l.Name as Language,
                                    pp.Description,
                                    pb.Id as PublisherId,
                                    pb.Name as Publisher,
                                    c.Id as CategoryId, 
                                    c.Name as Category, 
                                    w.Name as Writer, 
                                    w.Id as WriterId,
                                    w.Description as WriterDescription,
                                    pp.IsLimitedToStore,
                                    pp.IsShippingChargeApplicable,
                                    pp.IsReturnAble,
                                    pp.IsPublished,
                                    pp.IsNewProduct,
                                    pp.OrderMaximumQuantity,
                                    pp.OrderMinimumQuantity,
                                    pp.Edition,
                                    pp.NumberOfPage,
                                    pp.Isbn,
                                    pp.Sku,
                                    p.Title,
                                    pp.countryId,
                                    cn.Name as Country

                                    FROM ProductPublishers pp
                                    INNER JOIN Products p ON pp.ProductId = p.Id
                                    LEFT JOIN Writers w ON w.Id = p.WriterId
                                    LEFT JOIN Categories c ON c.Id = p.CategoryId
                                    LEFT JOIN Publishers pb ON pb.Id = pp.PublisherId
                                    LEFT JOIN Languages l ON l.Id = pp.LanguageId
                                    LEFT JOIN Countries cn ON cn.Id = pp.CountryId
                                    where pp.Id = @Id";


                command.CommandText = queryString;
                command.Parameters.Add(new SqlParameter("@Id", id));

                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            product.Id = Convert.ToInt32(reader["Id"]);
                            product.Name = reader["Name"].ToString();
                            product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                            product.Category = reader["Category"].ToString();
                            product.Language = reader["Language"].ToString();
                            product.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                            product.WriterId = Convert.ToInt32(reader["WriterId"]);
                            product.Writer = reader["Writer"].ToString();
                            product.PublisherId = Convert.ToInt32(reader["PublisherId"]);
                            product.Publisher = reader["Publisher"].ToString();
                            product.Country = reader["Country"].ToString();

                            product.Description = reader["Description"].ToString();
                            product.Title = reader["Title"].ToString();
                            product.Sku = reader["Sku"].ToString();
                            product.Isbn = reader["Isbn"].ToString();
                            product.NumberOfPage = Convert.ToInt32(reader["NumberOfPage"]);
                            product.Edition = reader["Edition"].ToString();
                            product.StockQuantity = Convert.ToInt32(reader["StockQuantity"]);
                            product.Price = Convert.ToDouble(reader["Price"]);
                            product.OldPrice = Convert.ToDouble(reader["OldPrice"]);
                            product.OrderMaximumQuantity = Convert.ToInt32(reader["OrderMaximumQuantity"]);
                            product.OrderMinimumQuantity = Convert.ToInt32(reader["OrderMinimumQuantity"]);
                            product.IsNewProduct = Convert.ToBoolean(reader["IsNewProduct"]);
                            product.IsPublished = Convert.ToBoolean(reader["IsPublished"]);
                            product.IsAproved = Convert.ToBoolean(reader["IsAproved"]);
                            product.IsReturnAble = Convert.ToBoolean(reader["IsReturnAble"]);
                            product.IsShippingChargeApplicable = Convert.ToBoolean(reader["IsShippingChargeApplicable"]);
                            product.IsLimitedToStore = Convert.ToBoolean(reader["IsLimitedToStore"]);
                        }

                    }

                }

            }

            return product;
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


        public async Task<ProductPublisher> GetProductPublisherByPublisherIdAsync(int id)
        {
           return await context.ProductPublishers.FindAsync(id);
        }
        public void AddProductPublisher(ProductPublisher productPublisher)
        {
            context.ProductPublishers.Add(productPublisher);
        }

        public async Task<List<ProductViewDto>> ReadData(string queryString)
        {
            List<ProductViewDto> products = new List<ProductViewDto>();
            
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;
                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductViewDto product = new ProductViewDto();
                            product.Id = Convert.ToInt32(reader["Id"]);
                            product.Name = reader["Name"].ToString();
                            product.Title = reader["Title"].ToString();
                            
                            //product.Description = reader["Description"].ToString();
                            product.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                            product.Category = reader["Category"].ToString();
                            //product.Language = reader["Language"].ToString();
                            product.Writer = reader["Writer"].ToString();
                            product.Publisher = reader["Publisher"].ToString();
                            product.PublisherId = Convert.ToInt32(reader["PublisherId"]);
                            product.Country = reader["Country"].ToString();
                            product.Writer = reader["Writer"].ToString();
                            product.Sku = reader["SKU"].ToString();
                            product.Isbn = reader["ISBN"].ToString();
                            product.NumberOfPage = Convert.ToDouble(reader["NumberOfPage"]);
                            product.Edition = reader["Edition"].ToString();
                            product.StockQuantity = Convert.ToInt32(reader["StockQuantity"]);
                            product.Price = Convert.ToDouble(reader["Price"]);
                            product.OldPrice = Convert.ToDouble(reader["OldPrice"]);
                            product.CostPrice = Convert.ToDouble(reader["CostPrice"]);
                            product.OrderMinimumQuantity = Convert.ToInt32(reader["OrderMinimumQuantity"]);
                            product.OrderMaximumQuantity = Convert.ToInt32(reader["OrderMaximumQuantity"]);
                            product.NotifyForMinimumQuantityBellow = Convert.ToInt32(reader["NotifyForMinimumQuantityBellow"]);
                            product.IsNewProduct = Convert.ToBoolean(reader["IsNewProduct"]);
                            product.IsPublished = Convert.ToBoolean(reader["IsPublished"]);
                            product.IsAproved = Convert.ToBoolean(reader["IsAproved"]);
                            product.IsReturnAble = Convert.ToBoolean(reader["IsReturnAble"]);
                            product.IsShippingChargeApplicable = Convert.ToBoolean(reader["IsShippingChargeApplicable"]);
                            product.IsLimitedToStore = Convert.ToBoolean(reader["IsLimitedToStore"]);
                            product.ProductPublisherId = Convert.ToInt32(reader["ProductPublisherId"]);
                            product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                            //product.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                            product.WriterId = Convert.ToInt32(reader["WriterId"]);
                            //product.CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString());
                            //product.UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"].ToString());
                            //product.CreatedBy = reader["CreatedBy"].ToString();
                            //product.UpdatedBy = reader["UpdatedBy"].ToString();
                            //product.DeletedBy = reader["DeletedBy"].ToString();
                            //product.IPAddress = reader["IPAddress"].ToString();
                            product.Photo = await context.Photos.Where(pt => pt.ProductPublisherId == product.ProductPublisherId).Select(pt => pt.FileName).FirstOrDefaultAsync();
                            
                            products.Add(product);
                        }
                        
                    }
                   // context.Database.CloseConnection();
                }
                context.Dispose();


            }

            return products;
        }

        // get products for register which products to be added to a banner
        public async Task<IEnumerable<ProductBannerView>> GetProductsForBanner(int bannerId)
        {
            var products = await context.ProductPublishers
                .Where(pp => pp.IsPublished == true && (pp.BannerId.GetValueOrDefault(0) == bannerId || pp.BannerId.GetValueOrDefault(0) == 0))
                .Select(pp => new ProductBannerView
                {
                    Id = pp.Id,
                    Product = pp.Product.Name,
                    Publisher = pp.Publisher.Name,
                    Quantity = pp.StockQuantity,
                    Price = pp.Price,
                    BannerId = pp.BannerId.GetValueOrDefault(),
                    Image = context.Photos.Where(p => p.ProductPublisherId == pp.Id).SingleOrDefault().FileName
                }).ToListAsync();
            return products;
           // products.Where(p => p.BannerId == bannerId || p.BannerId == 0);
            
        }

        public async Task<IEnumerable<ProductPublisher>> GetRegisteredProductsByBannerId(int bannerId)
        {
            return await context.ProductPublishers.Where(pp => pp.BannerId == bannerId).ToListAsync();
        }
       
        public async Task<List<int>> GetProductIdsThatIsRegisteredToABanner(int bannerId)
        {
            return await context.ProductPublishers.Where(pp => pp.BannerId == bannerId)
                .Select(pp => pp.Id)
                .ToListAsync();
        }
        public async Task<ProductPublisher> GetPruductPublisherById(int id)
        {
            var product = await context.ProductPublishers.SingleOrDefaultAsync(pp => pp.Id == id);
            return product;
        }

        //For clients 
        /*
         get product list for eatch (all) banner for home page
         */

        //product details for client 
        public async Task<ProductDetailDto> GetProdudctDetails(int id)
        {
            var product =await context.ProductPublishers
                .Where(pp => pp.Id == id)
                .Select(pp => new ProductDetailDto
                {
                    Id = pp.Id,
                    Name = pp.Product.Name,
                    CategoryId = pp.Product.CategoryId,
                    Category = pp.Product.Category.Name,
                    Language = context.Languages.SingleOrDefault(l => l.Id == pp.LanguageId).Name,
                    WriterId = pp.Product.WriterId,
                    Writer = pp.Product.Writer.Name,
                    PublisherId = pp.PublisherId,
                    Publisher = pp.Publisher.Name,
                    Country = context.Countries.SingleOrDefault(c => c.Id == pp.countryId).Name,
                    Photos = pp.Photos.Select(p => new PhotoDto{Id =p.Id, FileName =p.FileName }).ToList(),
                    Description = pp.Description,
                    Title = pp.Product.Title,
                    DisplayOrder = pp.Product.DisplayOrder,
                    Sku = pp.SKU,
                    Isbn = pp.ISBN,
                    NumberOfPage = pp.NumberOfPage,
                    Edition = pp.Edition,
                    StockQuantity = pp.StockQuantity,
                    Price = pp.Price,
                    OldPrice = pp.OldPrice,
                    CostPrice = pp.CostPrice,
                    OrderMaximumQuantity = pp.OrderMaximumQuantity,
                    OrderMinimumQuantity = pp.OrderMinimumQuantity,
                    IsNewProduct = pp.IsNewProduct,
                    IsPublished = pp.IsPublished,
                    IsAproved = pp.IsAproved,
                    IsReturnAble = pp.IsReturnAble,
                    IsShippingChargeApplicable = pp.IsShippingChargeApplicable,
                    IsLimitedToStore = pp.IsLimitedToStore
                })
                .SingleOrDefaultAsync();
           
            return product;
        }


        //products for eatch banner of home page
        public async Task<IEnumerable<ProductBannerClientView>> GetProductsBanners()
        {
            List<ProductBannerClientView> products = new List<ProductBannerClientView>();
            int isPublished = 1;
            
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                string queryString = @"SELECT pp.Id, p.Name, pp.StockQuantity as Quantity, pp.Price,b.Id as BannerId, b.Title,
                                    w.Id as WriterId, w.Name as Writer, pb.Id as PublisherId, pb.Name as Publisher
                                    FROM ProductPublishers pp
                                    LEFT JOIN Products p ON pp.ProductId = p.Id
									LEFT JOIN Writers w ON p.WriterId = w.Id
									LEFT JOIN Publishers pb ON pb.Id = pp.PublisherId
                                    INNER JOIN Banners b ON b.Id = pp.BannerId
									WHERE PP.IsPublished = @isPublished
                                    ORDER BY b.Id";
                command.CommandText = queryString;
                command.Parameters.Add(new SqlParameter("@isPublished", isPublished));
                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductBannerClientView product = new ProductBannerClientView();
                            product.Id = Convert.ToInt32(reader["Id"]);
                            product.Name = reader["Name"].ToString();
                            product.Quantity = Convert.ToInt32(reader["Quantity"]);
                            product.Price = Convert.ToDouble(reader["Price"]);
                            product.Writer = reader["Writer"].ToString();
                            product.WriterId = Convert.ToInt32(reader["WriterId"]);
                            product.Publisher = reader["Publisher"].ToString();
                            product.PublisherId = Convert.ToInt32(reader["PublisherId"]);
                            product.BannerId = Convert.ToInt32(reader["BannerId"]);
                            product.BannerTitle = reader["Title"].ToString();
                            var photo = context.Photos.Where(pt => pt.ProductPublisherId == product.Id).OrderBy(pt => pt.Id).Take(1).SingleOrDefault();
                            if (photo != null)
                                product.Image = photo.FileName;
                            else
                                product.Image = "";

                            products.Add(product);
                        }

                    }

                }

            }

            return products;
        }

        //Product list by eatch category 
        public async Task<IEnumerable<ProductClientView>> GetProductsByCategory(int categoryId)
        {
            List<ProductClientView> products = new List<ProductClientView>();
            int isPublished = 1;
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                try
                {
                    string queryString = @"SELECT pp.Id, p.Name, pp.StockQuantity as Quantity, pp.Price, pp.OldPrice, pb.Id as PublisherId,pb.Name as Publisher,
                                    c.Id as CategoryId, c.Name as Category, w.Name as Writer, w.Id as WriterId
                                    FROM ProductPublishers pp
                                    LEFT JOIN Products p ON pp.ProductId = p.Id
									LEFT JOIN Writers w ON w.Id = p.WriterId
									LEFT JOIN Publishers pb ON pb.Id = pp.PublisherId
                                    INNER JOIN Categories c ON c.Id = p.CategoryId
									where pp.IsPublished = @isPublished and c.Id = @CategoryId
                                    ORDER BY pp.Id,w.Id, pb.Id";

                    command.CommandText = queryString;
                    command.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
                    command.Parameters.Add(new SqlParameter("@isPublished", isPublished));

                    context.Database.OpenConnection();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductClientView product = new ProductClientView();
                                product.Id = Convert.ToInt32(reader["Id"]);
                                product.Name = reader["Name"].ToString();
                                product.Quantity = Convert.ToInt32(reader["Quantity"]);
                                product.Price = Convert.ToDouble(reader["Price"]);
                                product.OldPrice = Convert.ToDouble(reader["OldPrice"]);
                                product.Writer = reader["Writer"].ToString();
                                product.WriterId = Convert.ToInt32(reader["WriterId"]);
                                product.Publisher = reader["Publisher"].ToString();
                                product.PublisherId = Convert.ToInt32(reader["PublisherId"]);
                                product.Category = reader["Category"].ToString();
                                product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                                var photo = context.Photos.Where(pt => pt.ProductPublisherId == product.Id).OrderBy(pt => pt.Id).Take(1).SingleOrDefault();
                                if (photo != null)
                                    product.Image = photo.FileName;
                                else
                                    product.Image = "";

                                products.Add(product);
                            }

                        }

                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

            return products;
        }

        // product list by eatch writer 
        public async Task<IEnumerable<ProductClientView>> GetProductsByWriter(int writerId)
        {
            List<ProductClientView> products = new List<ProductClientView>();
            int isPublished = 1;
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                string queryString = @"SELECT pp.Id, p.Name, pp.StockQuantity as Quantity, pp.Price, pp.OldPrice, pb.Id as PublisherId,pb.Name as Publisher,c.Id as CategoryId, c.Name as Category
                                    ,c.Id as CategoryId, c.Name as Category, w.Name as Writer, w.Id as WriterId
                                    FROM ProductPublishers pp
                                    LEFT JOIN Products p ON pp.ProductId = p.Id
									LEFT JOIN Publishers pb ON pb.Id = pp.PublisherId
                                    LEFT JOIN Categories c ON c.Id = p.CategoryId
									INNER JOIN Writers w ON w.Id = p.WriterId
									where pp.IsPublished = @isPublished AND w.Id = @Id
                                    ORDER BY pp.Id, pb.Id";


                command.CommandText = queryString;
                command.Parameters.Add(new SqlParameter("@Id", writerId));
                command.Parameters.Add(new SqlParameter("@isPublished", isPublished));

                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductClientView product = new ProductClientView();
                            product.Id = Convert.ToInt32(reader["Id"]);
                            product.Name = reader["Name"].ToString();
                            product.Quantity = Convert.ToInt32(reader["Quantity"]);
                            product.Price = Convert.ToDouble(reader["Price"]);
                            product.Writer = reader["Writer"].ToString();
                            product.WriterId = Convert.ToInt32(reader["WriterId"]);
                            product.Publisher = reader["Publisher"].ToString();
                            product.PublisherId = Convert.ToInt32(reader["PublisherId"]);
                            product.Category = reader["Category"].ToString();
                            product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                            var photo = context.Photos.Where(pt => pt.ProductPublisherId == product.Id).OrderBy(pt => pt.Id).Take(1).SingleOrDefault();
                            if (photo != null)
                                product.Image = photo.FileName;
                            else
                                product.Image = "";

                            products.Add(product);
                        }

                    }

                }

            }

            return products;
        }

        //product list by eatch publisher
        public async Task<IEnumerable<ProductClientView>> GetProductsByPublisher(int publisherId)
        {
            List<ProductClientView> products = new List<ProductClientView>();
            int isPublished = 1;
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                string queryString = @"SELECT pp.Id, p.Name, pp.StockQuantity as Quantity, pp.Price, pp.OldPrice, pb.Id as PublisherId,pb.Name as Publisher,
                                    c.Id as CategoryId, c.Name as Category, w.Name as Writer, w.Id as WriterId
                                    FROM ProductPublishers pp
                                    LEFT JOIN Products p ON pp.ProductId = p.Id
									LEFT JOIN Writers w ON w.Id = p.WriterId
									LEFT JOIN Categories c ON c.Id = p.CategoryId
									INNER JOIN Publishers pb ON pb.Id = pp.PublisherId
									where pp.IsPublished = @isPublished AND pb.Id = @Id
                                    ORDER BY pp.Id,w.Id";


                command.CommandText = queryString;
                command.Parameters.Add(new SqlParameter("@Id", publisherId));
                command.Parameters.Add(new SqlParameter("@isPublished", isPublished));

                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductClientView product = new ProductClientView();
                            product.Id = Convert.ToInt32(reader["Id"]);
                            product.Name = reader["Name"].ToString();
                            product.Quantity = Convert.ToInt32(reader["Quantity"]);
                            product.Price = Convert.ToDouble(reader["Price"]);
                            product.Writer = reader["Writer"].ToString();
                            product.WriterId = Convert.ToInt32(reader["WriterId"]);
                            product.Publisher = reader["Publisher"].ToString();
                            product.PublisherId = Convert.ToInt32(reader["PublisherId"]);
                            product.Category = reader["Category"].ToString();
                            product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                            var photo = context.Photos.Where(pt => pt.ProductPublisherId == product.Id).OrderBy(pt => pt.Id).Take(1).SingleOrDefault();
                            if (photo != null)
                                product.Image = photo.FileName;
                            else
                                product.Image = "";

                            products.Add(product);
                        }

                    }

                }

            }

            return products;
        }
    }
}
