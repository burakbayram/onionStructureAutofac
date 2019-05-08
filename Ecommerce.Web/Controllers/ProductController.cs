using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Model;
using Ecommerce.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            ///tip olarak inarfeaeleir kullan sloid prensiplere uygun olarak kullandgımız icn
            IList<Product> liste = productService.GetAll();

            return View(liste);
        }

        public IActionResult Detay(string id)
        {
            var item = productService.Get(id);

            return View(item);
        }
        public IActionResult Create(string id)
        {
            var product = new Product();
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                p.UpdatedAt = DateTime.Now;
                p.UpdateBy = User.Identity.Name;
                p.CreatedAt = DateTime.Now;
                p.CreatedBy = User.Identity.Name;
                productService.Insert(p);
                return RedirectToAction("Index", "Product");
            }


            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", p.CategoryId);
            return View(p);
        }
        public IActionResult Edit(string id)
        {
            var product = productService.Get(id);
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                //Guvenlik acıgı olmasından hidden bolger bu kodları yazıyoourz
                var oldProduct = productService.Get(product.Id);
                oldProduct.Name = product.Name;
                oldProduct.Description = product.Description;
                oldProduct.Price = product.Price;
                oldProduct.CategoryId = product.CategoryId;
                oldProduct.UpdateBy = User.Identity.Name;
                oldProduct.UpdatedAt = DateTime.Now;
                productService.Update(oldProduct);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);

        }

        public IActionResult Delete(string id)
        {
       
                productService.Delete(id);
            return RedirectToAction("Index");
        }
  
        //public IActionResult Delete()
        //{


        //    return RedirectToAction("Index");
        //}


    }
}