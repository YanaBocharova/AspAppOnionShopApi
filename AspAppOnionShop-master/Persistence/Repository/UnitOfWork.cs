using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext db;

        IRepository<Guid, Product> _productsRepository;
        IRepository<Guid, Category> _categoriesRepository;
        public IRepository<Guid, Product> ProductsRepository => _productsRepository ?? (_productsRepository = new ProductsRepository(db));
        public IRepository<Guid, Category> CategoriesRepository => _categoriesRepository ?? (_categoriesRepository = new CategoriesRepository(db));

        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
        }

        public void SaveChanges() => db.SaveChanges();
    }
}
