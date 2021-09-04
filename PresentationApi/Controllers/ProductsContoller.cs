using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationApi.Models;
using PresentationApi.Models.Products;
using Services.Abstract;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsContoller : ControllerBase
    {
        IServiceManager serviceManager;
        IMapper mapper;
        public ProductsContoller(IServiceManager _serviceManager,IMapper _mapper)
        {
            serviceManager = _serviceManager;
            mapper = _mapper;
        }
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var products = serviceManager.ProductsService.GetAllProducts();
            return mapper.Map<IEnumerable<Product>>(products);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreatedProduct product)
        {
            var srchCategory = serviceManager.CategoriesService.GetCategoryByName(product.Category);

            Product prod = new Product
            {
                Name = product.Name,
                Price = product.Price,
            };
            prod.Category = mapper.Map<Category>(srchCategory);
            var create = mapper.Map<ProductDto>(prod);

            serviceManager.ProductsService.CreateNewProduct(create);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            serviceManager.ProductsService.RemoveProductById(id);
            return new JsonResult("Ok");
        }
        [HttpPut]
        public IActionResult Update(Product prod)
        {
            var srch = serviceManager.ProductsService.GetProductById((Guid)prod.Id);
            if (srch is null)
            {
                return BadRequest("Product was not found");
            }
            srch.Name = prod.Name;
            srch.Price = prod.Price;
            serviceManager.ProductsService.UpdateProduct(srch);

            return new JsonResult("Ok");
        }
    }
}
