using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecom.App.Controllers.Resources;
using Ecom.App.Controllers.Resources.DTOs;
using Ecom.App.Models;
using Ecom.App.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace Ecom.App.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment host;
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPhotoRepository photoRepository;
        private readonly IMapper mapper;
        private readonly PhotoSettings photoSettings;

        public FileController(IWebHostEnvironment host
            ,IProductRepository productRepository
            ,IUnitOfWork unitOfWork
            ,IOptionsSnapshot<PhotoSettings> options
            ,IPhotoRepository photoRepository
            ,IMapper mapper)
        {
            this.photoSettings = options.Value;
            this.host = host;
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.photoRepository = photoRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int productId, int publisherId, IFormFile file)
        {
            var productPublisher = await productRepository.GetProductPublisherAsync(new ProductPublisherIds { ProductId = productId, PublisherId = publisherId });
            if (productPublisher == null)
                return NotFound();

            if (file == null) return BadRequest("Null file");
            if (file.Length == 0) return BadRequest("Empty file");
            //if (file.Length > photoSettings.MaxBytes) return BadRequest("File is too large");
            //10 mb
            //if (!photoSettings.IsSupported(file.FileName)) return BadRequest("Invalid file type");


            var uploadFolderPath = Path.Combine(host.WebRootPath, "uploads");
            if (!Directory.Exists(uploadFolderPath))
                Directory.CreateDirectory(uploadFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            Photo photo = new Photo { FileName = fileName };
            productPublisher.Photos.Add(photo);
            await unitOfWork.SaveChangesAsync();

            return Ok(mapper.Map<Photo, PhotoDto>(photo));
        }

        [HttpPost]
        public async Task<IActionResult> GetAllByProductPublisher([FromBody]ProductPublisherIds data)
        {
            var productPublisher = await productRepository.GetProductPublisherAsync(new ProductPublisherIds { ProductId = data.ProductId, PublisherId = data.PublisherId });
            if (productPublisher == null)
                return BadRequest("Product or publisher is not set for photo");

            var photos = await photoRepository.GetAllPhotosByProductPublisherAsync(productPublisher.Id);
            return Ok(mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoDto>>(photos));
        }
    }
}
