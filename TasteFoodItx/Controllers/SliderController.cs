using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodItx.Context;
using TasteFoodItx.Entities;

using System.IO;

namespace TasteFoodItx.Controllers
{
    public class SliderController : Controller
    {
        TasteContext context = new TasteContext();

        public ActionResult SliderList()
        {
            ViewBag.v = context.Sliders.Count();
            var values = context.Sliders.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSlider(Slider slider, HttpPostedFileBase ImageFile)
        {
            if(ImageFile != null && ImageFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImageFile.FileName).Replace(" ", "_");
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/images"), fileName);

                ImageFile.SaveAs(path);

                slider.ImageUrl = "/Templates/tasteit-master/images/" + fileName;
            }

            context.Sliders.Add(slider);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var values = context.Sliders.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateSlider(Slider slider, HttpPostedFileBase ImageFile)
        {
            var values = context.Sliders.Find(slider.SliderId);
            
            values.Title = slider.Title;
            values.Header = slider.Header;
            values.Subheader = slider.Subheader;
            //values.ImageUrl = slider.ImageUrl;

            if(ImageFile != null && ImageFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImageFile.FileName).Replace(" ", "_");
                var path = Path.Combine(Server.MapPath("~/Templates/tasteit-master/images"), fileName);
                ImageFile.SaveAs(path);

                values.ImageUrl = "/Templates/tasteit-master/images/" + fileName;
            }
            else
            {
                values.ImageUrl = slider.ImageUrl;
            }

            context.SaveChanges();

            return RedirectToAction("SliderList");
        }

        public ActionResult DeleteSlider(int id)
        {
            var values = context.Sliders.Find(id);
            context.Sliders.Remove(values);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }


    }
}