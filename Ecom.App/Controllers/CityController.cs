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
    public class CityController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICityRepository cityRepository;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork unitOfWork,ICityRepository cityRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.cityRepository = cityRepository;
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
            var cities = await cityRepository.GetAllAsync();
            return Ok(cities);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var city = await cityRepository.GetAsync(id,false);
            return Ok(city);
        }

        private async Task<bool> isNameExist(string name)
        {
            var Names = await cityRepository.Names();
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
        public async Task<IActionResult> Create([FromBody] City city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await isNameExist(city.Name))
            {
                ModelState.AddModelError("Exist", "This city is already exist.");
                return BadRequest(ModelState);
            }
                
            cityRepository.Add(city);
            await unitOfWork.SaveChangesAsync();
            return CreatedAtAction("GetAsync", new { id = city.Id }, city);
           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] City city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var citydb = await cityRepository.GetAsync(id);
            if (citydb == null)
                return NotFound();

            citydb.Name = city.Name;
            citydb.CountryId = city.CountryId;
            await unitOfWork.SaveChangesAsync();
            
            return Ok(city);
        }

        public async Task<IActionResult> Delete(City city)
        {
            if (city == null)
                return BadRequest();

            cityRepository.Remove(city);
            await unitOfWork.SaveChangesAsync();

            return Ok(city);
        }
        
    }
}
