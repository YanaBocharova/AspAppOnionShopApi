using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ProductsRepository : BaseRepository<Guid, Product>
    {
        public ProductsRepository(ApplicationDbContext context) : base(context) { }

        public override IEnumerable<Product> GetAll()
        {
            return Table.Include(prod => prod.Category).ToList();
        }
        public override Product Get(Guid id)
        {
            var item = Table.Include(pr => pr.Category).FirstOrDefault(new Func<Product, bool>(itm => (itm as BaseEntity<Guid>).Id.Equals(id)));
            if (item is null)
            {
                throw new ArgumentNullException();
            }
            return item;
        }
        public override IEnumerable<Product> GetAll(Func<Product, bool> predicate)
        {
            return Table.Include(prod => prod.Category).Where(predicate).ToList();
        }

        public override void Remove(Guid id)
        {
            var item = Get(id);
            Table.Remove(item);
            db.SaveChanges();
        }

        public override void Update(Product item)
        {
            var srch = Get(item.Id);
            srch.Copy(item);
            db.SaveChanges();
        }

        public override Product Get(string name)
        {
            return Table.FirstOrDefault(item => item.Name.Equals(name));
        }
    }
}
