using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Ecom.App.Controllers.Resources;
using Ecom.App.Controllers.Resources.DTOs;
using Ecom.App.Models;
using Ecom.App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Ecom.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductRepository productRepository;
        private readonly IPublisherRepository publisherRepository;
        private readonly IMapper mapper;

        public ProductController(IUnitOfWork unitOfWork,
            IProductRepository productRepository, 
            IPublisherRepository publisherRepository, 
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
            this.publisherRepository = publisherRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            string sql = @"SELECT 
	                    p.[Id]
                      ,p.[Name]
	                  ,c.[Name] as Category
	                  --,l.[Name] as Language
	                  ,w.[Name] as Writer
	                  ,pb.[Name] as Publisher
                      ,pb.Id as PublisherId
	                  ,cn.[Name] as Country
                      ,p.[Title]
                     -- ,p.[Description]
					   ,ISNULL(p.[DisplayOrder], 0) as DisplayOrder
                      ,p.[CreatedAt]
                      ,p.[CreatedBy]
                      ,p.[UpdatedAt]
                      ,p.[UpdatedBy]
                      ,p.[DeletedAt]
                      ,p.[DeletedBy]
                      ,p.[PublishedDate]
                      ,p.[PublishedBy]
                      ,p.[IPAddress]
	                  ,ISNULL(pp.[CostPrice], 0) as CostPrice
                      ,pp.[Edition]
                      ,pp.[ISBN]
                      ,ISNULL(pp.[IsAproved], 0) as IsAproved
					  ,ISNULL(pp.[IsLimitedToStore], 0) as IsLimitedToStore
                      ,ISNULL(pp.[IsNewProduct], 0) as IsNewProduct
                      ,ISNULL(pp.[IsPublished], 0) as IsPublished
                      ,ISNULL(pp.[IsReturnAble], 0) as IsReturnAble
                      ,ISNULL(pp.[IsShippingChargeApplicable], 0) as IsShippingChargeApplicable
                      ,ISNULL(pp.[NotifyForMinimumQuantityBellow], 0) as NotifyForMinimumQuantityBellow
                      ,ISNULL(pp.[NumberOfPage], 0) as NumberOfPage
                      ,ISNULL(pp.[OldPrice], 0) as OldPrice
                      ,ISNULL(pp.[OrderMaximumQuantity], 0) as OrderMaximumQuantity
                      ,ISNULL(pp.[OrderMinimumQuantity], 0) as OrderMinimumQuantity
                      ,ISNULL(pp.[Price], 0) as Price
                      ,ISNULL(pp.[StockQuantity], 0) as StockQuantity
                      ,pp.[SKU] as Sku
                      ,ISNULL(pp.Id,0) as ProductPublisherId
                      ,ISNULL(p.CategoryId, 0)  as CategoryId
					   --,ISNULL(p.LanguageId, 0)  as LanguageId
					   ,ISNULL(p.WriterId, 0)  as WriterId
    
                FROM Products p
                LEFT JOIN ProductPublishers pp ON p.Id = pp.ProductId
                LEFT JOIN Publishers pb ON PP.PublisherId = pb.Id
                LEFT JOIN Countries cn ON pp.countryId = cn.Id
                LEFT JOIN Categories c ON p.CategoryId = c.Id
                --LEFT JOIN Languages l ON p.LanguageId = l.Id
                LEFT JOIN Writers w ON p.WriterId = w.Id";
            var products = await ((ProductRepository)productRepository).ReadData(sql);
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            
            var product = await productRepository.GetAsync(id);
            var result = mapper.Map<Product, ProductDto>(product);
            return Ok(result);
        }

        private bool isNameExist(string name)
        {
            var ProductNames = productRepository.getNames();
            if (ProductNames.Count == 0)
                return false;

            else
            {
                for (int i = 0; i < ProductNames.Count; i++)
                {
                    if(name == ProductNames[i])
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (isNameExist(productDto.Name))
            {
                ModelState.AddModelError("Exist", "Product name already exist.");
                return BadRequest(ModelState);
            }
                
           
            var product = mapper.Map<ProductDto, Product>(productDto);
            product.CreatedAt = DateTime.Now;
            productRepository.Add(product);
            await unitOfWork.SaveChangesAsync();

            product = await productRepository.GetAsync(product.Id, true);
            var result = mapper.Map<Product, ProductViewDto>(product);
            return CreatedAtAction("GetAsync", new { id = result.Id }, result);
           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await productRepository.GetAsync(id);
            if (product == null)
                return NotFound();

            mapper.Map<ProductDto, Product>(productDto, product);
            product.UpdatedAt = DateTime.Now;
            await unitOfWork.SaveChangesAsync();

            product = await productRepository.GetAsync(product.Id, true);
            var result = mapper.Map<Product, ProductViewDto>(product);
            return Ok(result);
        }

        public async Task<IActionResult> Delete(Product product)
        {
            if (product == null)
                return BadRequest();

            productRepository.Remove(product);
            await unitOfWork.SaveChangesAsync();

            return Ok(product);
        }

        
        [HttpPost]
        public async Task<IActionResult> GetProductPublisherAsync([FromBody] ProductPublisherIds data)
        {
            var productPubliser = await productRepository.GetProductPublisherAsync(data);
            if (productPubliser == null)
                return NotFound();
            return Ok(mapper.Map<ProductPublisher, ProductPublisherDto>(productPubliser));
        }

        string GetSKU(string productName, string publisherName)
        {
            string trimedProductName = productName.Trim();
            string trimedPublisherName = publisherName.Trim();
            string productNameWithoutWhatSpace = trimedProductName.Replace(" ", "");
            string publisherNameWithoutWhatSpace = trimedPublisherName.Replace(" ", "");

            string SKU = "";
            if(productNameWithoutWhatSpace.Length < 6)
            {
                SKU = productNameWithoutWhatSpace + "_";
            }
            else
            {
                SKU = productNameWithoutWhatSpace.Substring(0, 6) + "_";
            }

            if(publisherNameWithoutWhatSpace.Length < 6)
            {
                SKU = String.Concat(SKU, publisherNameWithoutWhatSpace);
            }
            else
            {
                SKU = String.Concat(SKU,publisherNameWithoutWhatSpace.Substring(0, 6));
            }
            return SKU;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductPublisher([FromBody] ProductPublisherDto productPublisherDto)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Product product = await productRepository.GetAsync(productPublisherDto.ProductId, false);
            Publisher publisher = await publisherRepository.GetAsync(productPublisherDto.PublisherId, false);
            productPublisherDto.SKU = GetSKU(product.Name, publisher.Name);

            if (product == null || publisher == null)
            {
                ModelState.AddModelError("product_publisher", "Product or publisher not found.");
                return BadRequest(ModelState);
            }

            var productPublisher = mapper.Map<ProductPublisherDto, ProductPublisher>(productPublisherDto);
            product.ProductPublishers.Add(productPublisher);
            await unitOfWork.SaveChangesAsync();

            productPublisher = await productRepository.GetProductPublisherAsync(new ProductPublisherIds { ProductId = productPublisher.ProductId, PublisherId = productPublisher .PublisherId});
            var result = mapper.Map<ProductPublisher, ProductPublisherDto>(productPublisher);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductPublisher([FromBody] ProductPublisherDto productPublisherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Product product = await productRepository.GetAsync(productPublisherDto.ProductId, false);
            Publisher publisher = await publisherRepository.GetAsync(productPublisherDto.PublisherId, false);
            productPublisherDto.SKU = GetSKU(product.Name, publisher.Name);

            if (productPublisherDto.ProductId == 0 || productPublisherDto.PublisherId == 0)
            {
                ModelState.AddModelError("productNull", "Product or publisher not found.");
                return BadRequest(ModelState);
            }

            var productPublisher = await productRepository.GetProductPublisherAsync(new ProductPublisherIds { ProductId = productPublisherDto.ProductId, PublisherId = productPublisherDto.PublisherId });
            mapper.Map<ProductPublisherDto, ProductPublisher>(productPublisherDto, productPublisher);
            await unitOfWork.SaveChangesAsync();

            productPublisher = await productRepository.GetProductPublisherAsync(new ProductPublisherIds { ProductId = productPublisher.ProductId, PublisherId = productPublisher.PublisherId });
            var result = mapper.Map<ProductPublisher, ProductPublisherDto>(productPublisher);
            return Ok(result);
        }
    }
}
