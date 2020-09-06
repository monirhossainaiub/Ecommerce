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
    public class CountryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICountryRepository categoryRepository;
        private readonly IMapper mapper;

        public CountryController(IUnitOfWork unitOfWork,ICountryRepository categoryRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.categoryRepository = categoryRepository;
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
            var categories = await categoryRepository.GetAllAsync();
            
            var categoryViewResource = mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(categories);
            return Ok(categoryViewResource);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            
            var category = await categoryRepository.GetAsync(id);
            var result = mapper.Map<Country, CountryDto>(category);
            return Ok(result);
        }

        private bool isNameExist(string name)
        {
            var categoryNames = categoryRepository.getCountryName();
            if (categoryNames.Count == 0)
                return false;

            else
            {
                for (int i = 0; i < categoryNames.Count; i++)
                {
                    if(name == categoryNames[i])
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (isNameExist(categoryDto.Name))
            {
                ModelState.AddModelError("Exist", "Country name already exist.");
                return BadRequest(ModelState);
            }
                
           
            var category = mapper.Map<CountryDto, Country>(categoryDto);
            
            categoryRepository.Add(category);
            await unitOfWork.SaveChangesAsync();

            var result = mapper.Map<Country, CountryDto>(category);
            return CreatedAtAction("GetAsync", new { id = result.Id }, result);
           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] CountryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await categoryRepository.GetAsync(id);
            if (category == null)
                return NotFound();

            mapper.Map<CountryDto, Country>(categoryDto,category);
            
            await unitOfWork.SaveChangesAsync();

            category = await categoryRepository.GetAsync(category.Id);
            var result = mapper.Map<Country, CountryDto>(category);

            return Ok(result);
        }

        public async Task<IActionResult> Delete(Country category)
        {
            if (category == null)
                return BadRequest();

            categoryRepository.Remove(category);
            await unitOfWork.SaveChangesAsync();

            return Ok(category);
        }
        
    }
}
