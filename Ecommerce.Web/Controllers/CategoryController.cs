using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Model;
using Ecommerce.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> liste = categoryService.GetAll();
            return View(liste);
        }

        public IActionResult Detay(string id)
        {
            var item = categoryService.Get(id);

            return View(item);
        }
        public IActionResult Create()
        {
            ///burdakı new lwmwmizn sebebi model isvalid false gelmesinn iye created date icin
            var cat = new Category();

            return View(cat);
        }
        [HttpPost]
        public IActionResult Create(Category cat)
        {
            if (ModelState.IsValid)
            {

                cat.CreatedAt = DateTime.Now;
                cat.CreatedBy = User.Identity.Name;
                cat.UpdateBy = User.Identity.Name;
                cat.UpdatedAt = DateTime.Now;
                categoryService.Insert(cat);
                return RedirectToAction("Index");
            }
            return View(cat);
        }
        public IEnumerable<Category> GetCategories()
        {

            return categoryService.GetAll();

        }
        public IActionResult Delete(string id)
        {

            categoryService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
         
                var cat = categoryService.Get(id);
            return View(cat);

       


        }
        [HttpPost]
        public IActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                var old = categoryService.Get(cat.Id);
                old.Name = cat.Name;
                old.Description = cat.Description;
                old.CreatedAt = cat.CreatedAt;
                old.CreatedBy = cat.CreatedBy;
                old.UpdateBy = cat.UpdateBy;
                old.UpdatedAt = cat.UpdatedAt;
                categoryService.Update(old);
                return RedirectToAction("Index");
            }
          
            return View(cat);




        }
    }
}