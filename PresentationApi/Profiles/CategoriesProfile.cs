using AutoMapper;
using PresentationApi.Models;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationApi.Profiles
{
    public class CategoriesProfile:Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
