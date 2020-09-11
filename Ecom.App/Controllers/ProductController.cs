using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper mapper;

        public ProductController(IUnitOfWork unitOfWork,IProductRepository productRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productRepository.GetAllAsync();
            
           // var results = mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewDto>>(products);
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
        
    }
}
