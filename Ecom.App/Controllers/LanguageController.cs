using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Ecom.App.Controllers.Resources.DTOs;
using Ecom.App.Models;
using Ecom.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.App.Controllers
{
    public class LanguageController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILanguageRepository languageRepository;
        private readonly IMapper mapper;

        public LanguageController(IUnitOfWork unitOfWork,ILanguageRepository languageRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.languageRepository = languageRepository;
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
            var language = await languageRepository.GetAllAsync();
            
            var result = mapper.Map<IEnumerable<Language>, IEnumerable<LanguageDto>>(language);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            
            var language = await languageRepository.GetAsync(id);
            var result = mapper.Map<Language, LanguageDto>(language);
            return Ok(result);
        }

        private bool isNameExist(string name)
        {
            var languageNames = languageRepository.getName();
            if (languageNames.Count == 0)
                return false;

            else
            {
                for (int i = 0; i < languageNames.Count; i++)
                {
                    if(name == languageNames[i])
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LanguageDto languageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (isNameExist(languageDto.Name))
            {
                ModelState.AddModelError("Exist", "Language name already exist.");
                return BadRequest(ModelState);
            }
                
            var language = mapper.Map<LanguageDto, Language>(languageDto);
            languageRepository.Add(language);
            await unitOfWork.SaveChangesAsync();

            var result = mapper.Map<Language, LanguageDto>(language);
            return CreatedAtAction("GetAsync", new { id = result.Id }, result);
           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] LanguageDto languageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var language = await languageRepository.GetAsync(id);
            if (language == null)
                return NotFound();

            mapper.Map<LanguageDto, Language>(languageDto,language);
            await unitOfWork.SaveChangesAsync();

            language = await languageRepository.GetAsync(language.Id);
            var result = mapper.Map<Language, LanguageDto>(language);

            return Ok(result);
        }

        public async Task<IActionResult> Delete(Language language)
        {
            if (language == null)
                return BadRequest();

            languageRepository.Remove(language);
            await unitOfWork.SaveChangesAsync();

            return Ok(language);
        }
        
    }
}
