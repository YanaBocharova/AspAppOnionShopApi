using AspAppOnionShop.Models.Categories;
using AspAppOnionShop.Models.Products;
using AutoMapper;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAppOnionShop.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductDto, ProductViewModel>();
            CreateMap<ProductViewModel, ProductDto>();

            CreateMap<CreateProductDto, CreateProduct>();
            CreateMap<CreateProduct, CreateProductDto>();

            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<CategoryViewModel, CategoryDto>();
        }
            
    }
}
