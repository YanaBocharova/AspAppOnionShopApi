using AspAppOnionShop.Models.Products;
using AspAppOnionShop.Sevices.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAppOnionShop.Controllers
{
    public class ProductsController : Controller
    {
        readonly IWebProductsService productsService;
        public ProductsController(IWebProductsService prodService)
        {
            this.productsService = prodService;
        }
        public IActionResult Index()
        {
            var prods = productsService.GetAllProducts();
            if (prods.Count > 0)
            {
                return View(new ProductsIndexViewModel
                {
                    Products = productsService.GetAllProducts(),
                    MaxPrice = productsService.GetAllProducts().Max(p => p.Price),
                    MinPrice = productsService.GetAllProducts().Min(p => p.Price),
                });
            }
            return View(new ProductsIndexViewModel
            {
                Products = productsService.GetAllProducts()
            });
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProduct product)
        {
            if (!ModelState.IsValid || product.Category == null)
            {
                ModelState.AddModelError("", "Model is not valid!");
                return View(product);
            }
          
            productsService.CreateNewProduct(product);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid? id)
        {
            if (id is null || productsService.GetProductById((Guid)id) is null)
            {
                return BadRequest("Product was not found");
            }
            productsService.RemoveProductById((Guid)id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid? id)
        {
            if (id is null || productsService.GetProductById((Guid)id) is null)
            {
                return BadRequest("Product was not found");
            }
            return View(productsService.GetProductById((Guid)id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel prod)
        {
            var srch = productsService.GetProductById((Guid)prod.Id);
            if (srch is null)
            {
                return BadRequest("Product was not found");
            }
            srch.Name = prod.Name;
            srch.Price = prod.Price;
            productsService.UpdateProduct(srch);
            return RedirectToAction("Index");
        }
    }
}
