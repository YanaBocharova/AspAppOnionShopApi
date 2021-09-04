using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(Guid id);
        void UpdateProduct(ProductDto product);
        void CreateNewProduct(ProductDto product);
        void RemoveProductById(Guid id);
    }
}
