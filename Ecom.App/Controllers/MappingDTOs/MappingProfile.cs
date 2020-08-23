using AutoMapper;
using Ecom.App.Controllers.Resources.DTOs;
using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Controllers.MappingDTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Category, CategoryDto>();

            CreateMap<Publisher, PublisherDto>();


            // API Resource to Domain
            CreateMap<CategoryDto, Category>();
            CreateMap<PublisherDto, Publisher>();
        }
    }
}
