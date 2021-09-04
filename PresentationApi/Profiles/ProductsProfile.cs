using AutoMapper;
using PresentationApi.Models;
using PresentationApi.Models.Products;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationApi.Profiles
{
    public class ProductsProfile:Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<ProductDto, CreateProductDto>();
            CreateMap<CreateProductDto, ProductDto>();
        }
    }
}
