using AspAppOnionShop.Models.Categories;
using AspAppOnionShop.Sevices.Abstraction;
using AutoMapper;
using Services.Abstract;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAppOnionShop.Sevices.Implemention
{
    public class WebCategoriesService : IWebCategoriesService
    {
        readonly IServiceManager serviceManager;
        private readonly IMapper mapper;
        public WebCategoriesService(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }
        public WebCategoriesService(IServiceManager serviceManager, IMapper _mapper)
        {
            this.serviceManager = serviceManager;
            mapper = _mapper;
        }
        public void CreateNewCategory(CategoryViewModel cat)
        {
            if (cat != null)
            {
                var createdCat = mapper.Map<CategoryDto>(cat);
                serviceManager.CategoriesService.CreateCategory(createdCat);
            }
        }
        public List<CategoryViewModel> GetAllCategories()
        {
            var categories = serviceManager.CategoriesService.GetAllCategories();
            return mapper.Map<List<CategoryViewModel>>(categories);
        }

        public CategoryViewModel GetCategoryById(Guid id)
        {
            var srch = serviceManager.CategoriesService.GetCategoryById(id);
            return mapper.Map<CategoryViewModel>(srch);
        }

        public CategoryViewModel GetCategoryByName(string name)
        {
            var srch = serviceManager.CategoriesService.GetCategoryByName(name);
            return mapper.Map<CategoryViewModel>(srch);
        }
        public void RemoveCategoryById(Guid id)
        {
            serviceManager.CategoriesService.RemoveCategoryById(id);
        }

        public void UpdateCategory(CategoryViewModel category)
        {
            var cat = mapper.Map<CategoryDto>(category);
            serviceManager.CategoriesService.UpdateCategory(cat);
        }
    }
}
