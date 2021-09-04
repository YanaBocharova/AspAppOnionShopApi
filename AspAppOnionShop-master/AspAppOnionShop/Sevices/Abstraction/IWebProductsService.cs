using AspAppOnionShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAppOnionShop.Sevices.Abstraction
{
    public interface IWebProductsService
    {
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductById(Guid id);
        void UpdateProduct(ProductViewModel product);
        void CreateNewProduct(CreateProduct product);
        void RemoveProductById(Guid id);
    }
}
