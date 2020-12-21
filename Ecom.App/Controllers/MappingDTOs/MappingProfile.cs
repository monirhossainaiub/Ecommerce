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
            CreateMap<Product, ProductViewDto>()
                .ForMember(pv => pv.Writer, opt => opt.MapFrom(p => p.Writer.Name))
                //.ForMember(pv => pv.Language, opt => opt.MapFrom(p => p.Language.Name))
                .ForMember(pv => pv.Category, opt => opt.MapFrom(p => p.Category.Name));
                


            CreateMap<ProductPublisher, ProductPublisherDto>();
            CreateMap<Publisher, PublisherDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Writer, WriterDto>();
            CreateMap<Language, LanguageDto>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<Slider, SliderDto>()
                .ForMember(sd => sd.Photo, opt => opt.MapFrom(s => s.Photo.FileName));
            


            // API Resource to Domain
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<PublisherDto, Publisher>();
            CreateMap<CountryDto, Country>();
            CreateMap<WriterDto, Writer>();
            CreateMap<LanguageDto, Language>();
            CreateMap<ProductPublisherDto, ProductPublisher>();
            CreateMap<SliderDto, Slider>();
        }
    }
}
