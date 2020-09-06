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
            CreateMap<Product, ProductDto>();
            CreateMap<Publisher, PublisherDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Writer, WriterDto>();



            // API Resource to Domain
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<PublisherDto, Publisher>();
            CreateMap<CountryDto, Country>();
            CreateMap<WriterDto, Writer>();
        }
    }
}
