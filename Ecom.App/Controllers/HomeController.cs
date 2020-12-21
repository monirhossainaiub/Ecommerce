using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ecom.App.Models;
using Ecom.App.Services;

namespace Ecom.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository productRepository;
        private readonly IPhotoRepository photoRepository;
        private readonly IBannerRepository bannerRepository;

        public HomeController(ILogger<HomeController> logger 
            ,IProductRepository productRepository
            ,IPhotoRepository photoRepository
            ,IBannerRepository bannerRepository)
            
        {
            _logger = logger;
            this.productRepository = productRepository;
            this.photoRepository = photoRepository;
            this.bannerRepository = bannerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
