using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodItx.Context;
using TasteFoodItx.Entities;

namespace TasteFoodItx.Controllers
{
    public class ProductController : Controller
    {
        TasteContext context = new TasteContext();

        [Authorize]
        public ActionResult ProductList()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;

            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
            p.IsActive = true;
            context.Products.Add(p);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        
        public ActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = context.Products.Find(id);

            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = categories;

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product p)
        {
            var values = context.Products.Find(p.ProductId);
            values.ProductName = p.ProductName;
            values.Description = p.Description;
            values.Price = p.Price;
            values.ImageUrl = p.ImageUrl;
            values.IsActive = true;
            values.CategoryId = p.CategoryId;

            context.SaveChanges();

            return RedirectToAction("ProductList");
        }






    }
}