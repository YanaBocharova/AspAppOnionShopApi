using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Category: BaseEntity<Guid>
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public void Copy(Category from)
        {
            Name = from.Name;
        }
    }
}
