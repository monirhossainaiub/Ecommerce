﻿using System;
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
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryController(IUnitOfWork unitOfWork,ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.categoryRepository = categoryRepository;
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
            var categories = await categoryRepository.GetAllAsync();
            
            var categoryViewResource = mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
            return Ok(categoryViewResource);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            
            var category = await categoryRepository.GetAsync(id);
            var result = mapper.Map<Category, CategoryDto>(category);
            return Ok(result);
        }

        private bool isNameExist(string name)
        {
            var categoryNames = categoryRepository.getCategoryName();
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
        public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (isNameExist(categoryDto.Name))
            {
                ModelState.AddModelError("Exist", "Category name already exist.");
                return BadRequest(ModelState);
            }
                
           
            var category = mapper.Map<CategoryDto, Category>(categoryDto);
            category.CreatedAt = DateTime.Now;
            categoryRepository.Add(category);
            await unitOfWork.SaveChangesAsync();

            var result = mapper.Map<Category, CategoryDto>(category);
            return CreatedAtAction("GetAsync", new { id = result.Id }, result);
           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await categoryRepository.GetAsync(id);
            if (category == null)
                return NotFound();

            mapper.Map<CategoryDto, Category>(categoryDto,category);
            category.UpdatedAt = DateTime.Now;
            await unitOfWork.SaveChangesAsync();

            category = await categoryRepository.GetAsync(category.Id);
            var result = mapper.Map<Category, CategoryDto>(category);

            return Ok(result);
        }

        public async Task<IActionResult> Delete(Category category)
        {
            if (category == null)
                return BadRequest();

            categoryRepository.Remove(category);
            await unitOfWork.SaveChangesAsync();

            return Ok(category);
        }
        
    }
}
