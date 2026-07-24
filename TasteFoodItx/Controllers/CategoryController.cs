using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodItx.Context;
using TasteFoodItx.Entities;

namespace TasteFoodItx.Controllers
{
    public class CategoryController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }


        public ActionResult DeleteCategory(int id)
        {
            var values = context.Categories.Find(id);
            context.Categories.Remove(values);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = context.Categories.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var values = context.Categories.Find(category.CategoryId);
            values.CategoryName = category.CategoryName;

            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }


        public ActionResult GetDetailCategory(int id)
        {
            var kategori = context.Categories.Find(id);

            if(kategori == null)
            {
                return HttpNotFound();
            }

            ViewBag.kategoriAdi = kategori.CategoryName;

            var urunler = context.Products.Where(x => x.CategoryId == id).ToList();


             return View(urunler);
        }











    }
}