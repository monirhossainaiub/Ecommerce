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
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Ecom.App.Controllers.Resources;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Ecom.App.Controllers
{
    public class SliderController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ISliderRepository sliderRepository;
        private readonly IWebHostEnvironment host;
        private readonly IPhotoRepository photoRepository;
        private readonly PhotoSettings photoSettings;
        private readonly IMapper mapper;

        public SliderController(IUnitOfWork unitOfWork
            ,ISliderRepository sliderRepository
            ,IWebHostEnvironment host
            , IOptionsSnapshot<PhotoSettings> options
            ,IPhotoRepository photoRepository
            , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.sliderRepository = sliderRepository;
            this.photoSettings = options.Value;
            this.host = host;
            this.photoRepository = photoRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Upload(bool isActive, string controllerName, string actionName, IFormFile file)
        //{

        //    if (file == null) return BadRequest("Null file");
        //    if (file.Length == 0) return BadRequest("Empty file");

        //    var uploadFolderPath = Path.Combine(host.WebRootPath, "uploads");
        //    if (!Directory.Exists(uploadFolderPath))
        //        Directory.CreateDirectory(uploadFolderPath);

        //    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //    var filePath = Path.Combine(uploadFolderPath, fileName);

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    Photo photo = new Photo { FileName = fileName };
        //    photo.IsSliderPhoto = true;
        //    Slider slider = new Slider();
        //    slider.Photo = photo;
        //    slider.IsActive = isActive;
        //    slider.ControllerName = controllerName;
        //    slider.ActionName = actionName;
        //    sliderRepository.Add(slider);
        //    await unitOfWork.SaveChangesAsync();

        //    return Ok(slider);
        //}

        [HttpPost]
        public async Task<IActionResult> Upload(SliderDto sliderDto , IFormFile file)
        {
            Slider slider = new Slider();
            if (sliderDto.Id > 0)
            {
                //update
            }
            else
            {
                if (file == null) return BadRequest("Null file");
                if (file.Length == 0) return BadRequest("Empty file");

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

               
                slider.Photo = photo;
                slider.ControllerName = sliderDto.ControllerName;
                slider.ActionName = sliderDto.ActionName;
                slider.DisplayOrder = sliderDto.DisplayOrder;
                slider.IsActive = sliderDto.IsActive;

                sliderRepository.Add(slider);
            }
           
            await unitOfWork.SaveChangesAsync();

            return Ok(slider);
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Photo photo)
        {
            string uploadFolderPath = Path.Combine(host.WebRootPath, "uploads");
            string filePath = Path.Combine(uploadFolderPath, photo.FileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);

                photoRepository.Delete(photo);
                await unitOfWork.SaveChangesAsync();
                return Ok(photo);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sliders = await sliderRepository.GetAllAsync();
            return Ok(sliders);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var slider = await sliderRepository.GetAsync(id);
            return Ok(slider);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Slider slider)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            sliderRepository.Add(slider);
            await unitOfWork.SaveChangesAsync();
            return CreatedAtAction("GetAsync", new { id = slider.Id }, slider);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] SliderDto slider)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sliderDb = await sliderRepository.GetAsync(id);

            if (sliderDb == null)
                return NotFound();

            sliderDb.ControllerName = slider.ControllerName;
            sliderDb.ActionName = slider.ActionName;
            sliderDb.PhotoId = slider.PhotoId;
            sliderDb.IsActive = slider.IsActive;
            sliderDb.DisplayOrder = slider.DisplayOrder;

            await unitOfWork.SaveChangesAsync();

            var result = await sliderRepository.GetAsync(sliderDb.Id);
            return Ok(result);
        }

        public async Task<IActionResult> Delete(Slider slider)
        {
            if (slider == null)
                return BadRequest();

            sliderRepository.Remove(slider);
            await unitOfWork.SaveChangesAsync();
            return Ok(slider);
        }
        
    }
}
