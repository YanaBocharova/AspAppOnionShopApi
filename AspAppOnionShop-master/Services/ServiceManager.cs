using AutoMapper;
using Domain.Repository;
using Services.Abstract;
using Services.AutoMaper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductsService> _productsService;

        private readonly Lazy<ICategoriesService> _categoriesService;

        private readonly IMapper mapper;
        public ServiceManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mappingConfig.CreateMapper();

            _productsService = new Lazy<IProductsService>(() => new ProductsService(unitOfWork, mapper));
            _categoriesService = new Lazy<ICategoriesService>(() => new CategoriesService(unitOfWork, mapper));
        }

        public ICategoriesService CategoriesService => _categoriesService.Value;
        public IProductsService ProductsService => _productsService.Value;
    }
}
