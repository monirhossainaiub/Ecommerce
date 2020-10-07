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
    public class BannerController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IBannerRepository bannerRepository;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public BannerController(IUnitOfWork unitOfWork,
            IBannerRepository bannerRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.bannerRepository = bannerRepository;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> getProducts()
        {
            return Ok(await productRepository.GetProductsForBanner());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var banners = await bannerRepository.GetAllAsync();
            return Ok(banners);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            
            var banners = await bannerRepository.GetAsync(id,false);
            return Ok(banners);
        }

        private async Task<bool> isNameExist(string name)
        {
            var Names = await bannerRepository.Names();
            if (Names.Count == 0)
                return false;

            else
            {
                for (int i = 0; i < Names.Count; i++)
                {
                    if(name == Names[i])
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Banner banner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await isNameExist(banner.Title))
            {
                ModelState.AddModelError("Exist", "Banner is already exist.");
                return BadRequest(ModelState);
            }
                
            bannerRepository.Add(banner);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetAsync", new { id = banner.Id }, banner);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] Banner banner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bannerdb = await bannerRepository.GetAsync(id);
            if (banner == null)
                return NotFound();

            bannerdb.Title = banner.Title;
            bannerdb.DisplayOrder = banner.DisplayOrder;
            bannerdb.IsActive = banner.IsActive;

            await unitOfWork.SaveChangesAsync();
            return Ok(bannerdb);
        }

        public async Task<IActionResult> Delete(Banner banner)
        {
            if (banner == null)
                return BadRequest();

            bannerRepository.Remove(banner);
            await unitOfWork.SaveChangesAsync();

            return Ok(banner);
        }
        
    }
}
