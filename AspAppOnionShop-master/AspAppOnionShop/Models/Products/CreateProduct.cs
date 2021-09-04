using AspAppOnionShop.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAppOnionShop.Models.Products
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
