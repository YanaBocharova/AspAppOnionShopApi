using AspAppOnionShop.Models.Categories;
using AspAppOnionShop.Sevices.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAppOnionShop.Controllers
{
    public class CategoriesController : Controller
    {
        private IWebCategoriesService categoriesService;
        public CategoriesController(IWebCategoriesService _categoriesService)
        {
            categoriesService = _categoriesService;
        }
        public IActionResult Index()
        {
            return View(new CategoriesIndexViewModel()
            {
               Categories = categoriesService.GetAllCategories()
            });
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryViewModel category)
        {
            categoriesService.CreateNewCategory(category);
            return RedirectToRoute(new { controller = "Products", action = "Index" });
        }
        public IActionResult Edit(Guid? id)
        {
            if (id is null || categoriesService.GetCategoryById((Guid)id) is null)
            {
                return BadRequest("Category was not found");
            }
            return View(categoriesService.GetCategoryById((Guid)id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryViewModel category)
        {
            var srch = categoriesService.GetCategoryById((Guid)category.Id);
            if (srch is null)
            {
                return BadRequest("Product was not found");
            }
            srch.Name = category.Name;
            categoriesService.UpdateCategory(srch);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid? id)
        {
            if (id is null || categoriesService.GetCategoryById((Guid)id) is null)
            {
                return BadRequest("Product was not found");
            }
            categoriesService.RemoveCategoryById((Guid)id);
            return RedirectToAction("Index");
        }
    }
}
