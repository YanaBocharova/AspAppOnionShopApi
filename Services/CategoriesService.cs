using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using Services.Abstract;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoriesService : BaseService,ICategoriesService
    {
        public CategoriesService(IUnitOfWork uow,IMapper _mapper):base(uow, _mapper)
        {
            mapper = _mapper;
            unitOfWork = uow;
        }
        public void CreateCategory(CategoryDto category)
        {
            var categoryNew = mapper.Map<Category>(category);
            unitOfWork.CategoriesRepository.Create(categoryNew);
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = unitOfWork.CategoriesRepository.GetAll();
            return mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public CategoryDto GetCategoryById(Guid id)
        {
            var srch = unitOfWork.CategoriesRepository.Get(id);
            return mapper.Map<CategoryDto>(srch);
        }

        public CategoryDto GetCategoryByName(string name)
        {
            var srch = unitOfWork.CategoriesRepository.Get(name);
            return mapper.Map<CategoryDto>(srch);
        }

        public void RemoveCategoryById(Guid id)
        {
            unitOfWork.CategoriesRepository.Remove(id);
        }

        public void UpdateCategory(CategoryDto category)
        {
            var editCategory= mapper.Map<Category>(category);
            unitOfWork.CategoriesRepository.Update(editCategory);
            unitOfWork.SaveChanges();
        }
    }
}
