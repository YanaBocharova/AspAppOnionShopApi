using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryById(Guid id);
        CategoryDto GetCategoryByName(string name);
        void UpdateCategory(CategoryDto category);
        void CreateCategory(CategoryDto category);
        void RemoveCategoryById(Guid id);
    }
}
