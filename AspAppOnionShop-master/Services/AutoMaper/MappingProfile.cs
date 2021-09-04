using AutoMapper;
using Domain.Entity;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AutoMaper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();


            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

        }
    }
}
