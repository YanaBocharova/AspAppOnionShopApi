using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class CategoriesRepository : BaseRepository<Guid, Category>
    {
        public CategoriesRepository(ApplicationDbContext context) : base(context) { }
        public override Category Get(Guid id)
        {
            var item = Table.FirstOrDefault(new Func<Category, bool>(itm => (itm as BaseEntity<Guid>).Id.Equals(id)));
            if (item is null)
            {
                throw new ArgumentNullException();
            }
            return item;
        }

        public override Category Get(string name)
        {
            return Table.FirstOrDefault(item => item.Name.Equals(name));
        }
        public override void Remove(Guid id)
        {
            var item = Get(id);
            Table.Remove(item);
            db.SaveChanges();
        }
        public override void Update(Category item)
        {
            var srch = Get(item.Id);
            srch.Copy(item);
            db.SaveChanges();
        }
    }
}
