using AspAppOnionShop.Models.Categories;
using AspAppOnionShop.Models.Products;
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
    public class WebProductsService : IWebProductsService
    {
        readonly IServiceManager serviceManager;
        private readonly IMapper mapper;
        public WebProductsService(IServiceManager serviceManager,IMapper _mapper)
        {
            this.serviceManager = serviceManager;
            mapper = _mapper;
    }
        public void CreateNewProduct(CreateProduct product)
        {
           var srchCategory = serviceManager.CategoriesService.GetCategoryByName(product.Category);
            ProductViewModel prod = new ProductViewModel
            {
                Name = product.Name,
                Price = product.Price,
            };
            prod.Category = mapper.Map<CategoryViewModel>(srchCategory);
            var create = mapper.Map<ProductDto>(prod);
            serviceManager.ProductsService.CreateNewProduct(create);
        }

        public List<ProductViewModel> GetAllProducts()
        {
            var products = serviceManager.ProductsService.GetAllProducts();
            return mapper.Map<List<ProductViewModel>>(products);
        }

        public ProductViewModel GetProductById(Guid id)
        {
            var srch = serviceManager.ProductsService.GetProductById(id);
            return mapper.Map<ProductViewModel>(srch);
        }

        public void RemoveProductById(Guid id)
        {
            serviceManager.ProductsService.RemoveProductById(id);
        }

        public void UpdateProduct(ProductViewModel product)
        {

            var prodEdit = mapper.Map<ProductDto>(product);
            serviceManager.ProductsService.UpdateProduct(prodEdit);
        }
    }
}
