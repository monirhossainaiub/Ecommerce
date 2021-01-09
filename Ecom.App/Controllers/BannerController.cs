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

        //get products for banner where bannaerId == null or provided bannerId
        [HttpPost]
        public async Task<IActionResult> GetProducts([FromBody] int id)
        {
            return Ok(await productRepository.GetProductsForBanner(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var banners = await bannerRepository.GetAllAsync();
            return Ok(banners);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActive()
        {
            var banners = await bannerRepository.GetAllActiveAsync();
            return Ok(banners);
        }


        [HttpGet]
        public async Task<IActionResult> GetBannersWithProducts()
        {
            var banners = await bannerRepository.GetAllActiveBannersWithProductsAsync(12);
            return Ok(banners);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            var banners = await bannerRepository.GetAsync(id, false);
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
                    if (name == Names[i])
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

        [HttpPost]
        public async Task<IActionResult> RegisterProducts([FromBody] ProductBannerRegister data)
        {
            var banner = await bannerRepository.GetAsync(data.BannerId);
            var productIds = await productRepository.GetProductIdsThatIsRegisteredToABanner(data.BannerId);

            if(productIds.Count == 0)
            {
                foreach (var productPublisherId in data.ProductIds)
                {
                    var product = await productRepository.GetPruductPublisherById(productPublisherId);

                    banner.ProductPublishers.Add(product);
                }
            }
            else
            {
                for (int i = 0; i < data.ProductIds.Count; i++)
                {

                    bool isAdded = true;
                    for (int j = 0; j < productIds.Count; j++)
                    {
                        if (data.ProductIds[i] == productIds[j])
                        {
                            isAdded = false;
                            break;
                        }
                    }
                    if (isAdded)
                    {
                        var product = await productRepository.GetPruductPublisherById(data.ProductIds[i]);
                        banner.ProductPublishers.Add(product);
                    }
                    

                }

                for (int i = 0; i < productIds.Count; i++)
                {
                    bool isRemoved = true;

                    for (int j = 0; j < data.ProductIds.Count; j++)
                    {
                        if (productIds[i] == data.ProductIds[j])
                        {
                            isRemoved = false;
                            break;
                        }
                       
                    }
                    if(isRemoved)
                    {
                        var product = await productRepository.GetPruductPublisherById(productIds[i]);
                        banner.ProductPublishers.Remove(product);
                    }
                }
            }
            
            
            

            await unitOfWork.SaveChangesAsync();
            return Ok();
        }

    }
}
