using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationApi.Models.Products
{
    public class CreatedProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
