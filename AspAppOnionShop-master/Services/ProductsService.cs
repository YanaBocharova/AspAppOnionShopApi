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
    public class ProductsService:BaseService ,IProductsService
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ProductsService(IUnitOfWork uow, IMapper _mapper):base(uow, _mapper)
        {
            unitOfWork = uow;
            mapper = _mapper;
        }
   
        public void CreateNewProduct(ProductDto product)
        {
            if (product != null && product.Category != null)
            {
                var createdProduct = mapper.Map<Product>(product);
                unitOfWork.ProductsRepository.Create(createdProduct);
                unitOfWork.SaveChanges();
            }
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = unitOfWork.ProductsRepository.GetAll();
            return mapper.Map<IEnumerable<ProductDto>>(products);

        }

        public ProductDto GetProductById(Guid id)
        {
            var prod = unitOfWork.ProductsRepository.Get(id);
            return mapper.Map<ProductDto>(prod);
        }

        public void RemoveProductById(Guid id)
        {
            unitOfWork.ProductsRepository.Remove(id);
            unitOfWork.SaveChanges();
        }

        public void UpdateProduct(ProductDto product)
        {
            var editProduct = mapper.Map<Product>(product);
            unitOfWork.ProductsRepository.Update(editProduct);
            unitOfWork.SaveChanges();
        }
    }
}
