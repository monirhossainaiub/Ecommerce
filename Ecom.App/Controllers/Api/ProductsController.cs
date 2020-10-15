using Ecom.App.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecom.App.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

       
        public ProductsController(IProductRepository productRepository,IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        //// GET: api/<ProductsController>
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var products = await productRepository.GetProductsBanners();
            return Ok(products);
        }

        [HttpGet]
        [Route("category/{id:int}")]
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            var products = await productRepository.GetProductsByCategory(id);
            return Ok(products);
        }

        // get product list for by each writer
        [HttpGet]
        [Route("writer/{id:int}")]
        public async Task<IActionResult> GetProductsByWriter(int id)
        {
            var products = await productRepository.GetProductsByWriter(id);
            return Ok(products);
        }

        // get product list for each publisher
        [HttpGet]
        [Route("publisher/{id:int}")]
        public async Task<IActionResult> GetProductsByPublisher(int id)
        {
            var products = await productRepository.GetProductsByPublisher(id);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await productRepository.GetAsync(id, includeRelated: true);
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
