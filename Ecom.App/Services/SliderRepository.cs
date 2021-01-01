using Ecom.App.Controllers.Resources.DTOs;
using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class SliderRepository : ISliderRepository
    {
        private readonly ApplicationDbContext context;
        public SliderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Slider slider)
        {
            context.Sliders.Add(slider);
            
        }

        public async Task<IEnumerable<SliderDto>> GetAllAsync()
        {
            return await context.Sliders
                .Select(s => new SliderDto
                {
                    Id = s.Id,
                    Photo = s.Photo.FileName,
                    PhotoId = s.Photo.Id,
                    ControllerName = s.ControllerName,
                    ActionName = s.ActionName,
                    DisplayOrder = s.DisplayOrder,
                    IsActive = s.IsActive
                })
                .ToListAsync();
        }

        public async Task<SliderDto> GetAsync(int id)
        {
            return await context.Sliders
                .Select(s => new SliderDto
                {
                    Id = s.Id,
                    ControllerName = s.ControllerName,
                    ActionName = s.ActionName,
                    Photo = s.Photo.FileName,
                    PhotoId = s.Photo.Id,
                    DisplayOrder = s.DisplayOrder,
                    IsActive = s.IsActive
                })
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Remove(Slider slider)
        {
            context.Sliders.Remove(slider);
        }

       
    }
}
