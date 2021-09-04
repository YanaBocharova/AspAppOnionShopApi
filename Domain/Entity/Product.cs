using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Product: BaseEntity<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        public void Copy(Product from)
        {
            Name = from.Name;
            Price = from.Price;
        }
    }
}
