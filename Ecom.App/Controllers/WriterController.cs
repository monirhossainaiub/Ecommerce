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
    public class WriterController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWriterRepository writerRepository;
        private readonly IMapper mapper;

        public WriterController(IUnitOfWork unitOfWork,IWriterRepository writerRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.writerRepository = writerRepository;
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
            var writers = await writerRepository.GetAllAsync();
            var result = mapper.Map<IEnumerable<Writer>, IEnumerable<WriterDto>>(writers);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            
            var writer = await writerRepository.GetAsync(id,false);
            var result = mapper.Map<Writer, WriterDto>(writer);
            return Ok(result);
        }

        private async Task<bool> isNameExist(string name)
        {
            var Names = await writerRepository.Names();
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
        public async Task<IActionResult> Create([FromBody] WriterDto writerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await isNameExist(writerDto.Name))
            {
                ModelState.AddModelError("Exist", "Writer name already exist.");
                return BadRequest(ModelState);
            }
                
           
            var writer = mapper.Map<WriterDto, Writer>(writerDto);
            writer.CreatedAt = DateTime.Now;
            writerRepository.Add(writer);
            await unitOfWork.SaveChangesAsync();

            var result = mapper.Map<Writer, WriterDto>(writer);
            return CreatedAtAction("GetAsync", new { id = result.Id }, result);
           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] WriterDto writerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var writer = await writerRepository.GetAsync(id);
            if (writer == null)
                return NotFound();

            mapper.Map<WriterDto, Writer>(writerDto,writer);
            writer.UpdatedAt = DateTime.Now;
            await unitOfWork.SaveChangesAsync();

            writer = await writerRepository.GetAsync(writer.Id);
            var result = mapper.Map<Writer, WriterDto>(writer);

            return Ok(result);
        }

        public async Task<IActionResult> Delete(Writer writer)
        {
            if (writer == null)
                return BadRequest();

            writerRepository.Remove(writer);
            await unitOfWork.SaveChangesAsync();

            return Ok(writer);
        }
        
    }
}
