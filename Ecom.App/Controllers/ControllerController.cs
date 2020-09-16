using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ecom.App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Ecom.App.Controllers
{
    public class ControllerController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IHostEnvironment host;

        public ControllerController(IProductRepository productRepository,IHostEnvironment host)
        {
            this.productRepository = productRepository;
            this.host = host;
        }
        //[HttpPost]
        //public async Task<IActionResult> Upload(int productId, IFormFile file)
        //{
        //    var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
        //    if (!Directory.Exists(uploadsFolderPath))
        //        Directory.CreateDirectory(uploadsFolderPath);

        //    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //    var filePath = Path.Combine(uploadsFolderPath, fileName);

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    var product = productRepository.GetAsync(productId, false);

        //}
    }
}
