using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AboutController : Controller
    {
        TasteContext context = new TasteContext();

        [AllowAnonymous]

        [HttpGet]
        public ActionResult AboutList()
        {
            var values = context.Abouts.FirstOrDefault();
            return View(values);
        }

        [HttpPost]
        public ActionResult AboutList(About p)
        {
            var values = context.Abouts.Find(p.AboutId);
            values.Title = p.Title;
            values.ImageUrl = p.ImageUrl;
            values.Description = p.Description;
            context.SaveChanges();
            return RedirectToAction("AboutLists");
        }
    }
}