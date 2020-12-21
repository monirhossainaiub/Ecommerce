using Ecom.App.Controllers.Resources.DTOs;
using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface ISliderRepository
    {

        Task<SliderDto> GetAsync(int id);
        void Add(Slider slider);
        Task<IEnumerable<SliderDto>> GetAllAsync();
        void Remove(Slider slider);
    }
}
