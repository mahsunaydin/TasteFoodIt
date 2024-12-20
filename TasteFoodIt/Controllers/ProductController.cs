﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
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
            var values = context.Products.Find(id);
            context.Products.Remove(values);
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
            ViewBag.StatusList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Aktif", Value = "1"},
                new SelectListItem { Text = "Pasif", Value = "0"}
            };
            ViewBag.v = categories;
            return View(value);

        }


        [HttpPost]
        public ActionResult UpdateProduct(Product p)
        {
            var value = context.Products.Find(p.ProductId);
            value.CategoryId = p.CategoryId;
            value.ProductName = p.ProductName;
            value.ImageUrl = p.ImageUrl;
            value.IsActive = p.IsActive; ;
            value.Price = p.Price;
            value.Description = p.Description;
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }









    }
}