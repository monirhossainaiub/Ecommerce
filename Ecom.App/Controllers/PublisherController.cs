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
    public class PublisherController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublisherRepository publisherRepository;
        private readonly IMapper mapper;

        public PublisherController(IUnitOfWork unitOfWork,IPublisherRepository publisherRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.publisherRepository = publisherRepository;
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
            var publishers = await publisherRepository.GetAllAsync();
            
            var result = mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherDto>>(publishers);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            
            var publisher = await publisherRepository.GetAsync(id,false);
            var result = mapper.Map<Publisher, PublisherDto>(publisher);
            return Ok(result);
        }

        private async Task<bool> isNameExist(string name)
        {
            var Names = await publisherRepository.Names();
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
        public async Task<IActionResult> Create([FromBody] PublisherDto publisherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await isNameExist(publisherDto.Name))
            {
                ModelState.AddModelError("Exist", "Publisher name already exist.");
                return BadRequest(ModelState);
            }
                
           
            var publisher = mapper.Map<PublisherDto, Publisher>(publisherDto);
            publisher.CreatedAt = DateTime.Now;
            publisherRepository.Add(publisher);
            await unitOfWork.SaveChangesAsync();

            var result = mapper.Map<Publisher, PublisherDto>(publisher);
            return CreatedAtAction("GetAsync", new { id = result.Id }, result);
           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] PublisherDto publisherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var publisher = await publisherRepository.GetAsync(id);
            if (publisher == null)
                return NotFound();

            mapper.Map<PublisherDto, Publisher>(publisherDto,publisher);
            publisher.UpdatedAt = DateTime.Now;
            await unitOfWork.SaveChangesAsync();

            publisher = await publisherRepository.GetAsync(publisher.Id);
            var result = mapper.Map<Publisher, PublisherDto>(publisher);

            return Ok(result);
        }

        public async Task<IActionResult> Delete(Publisher publisher)
        {
            if (publisher == null)
                return BadRequest();

            publisherRepository.Remove(publisher);
            await unitOfWork.SaveChangesAsync();

            return Ok(publisher);
        }
        
    }
}
