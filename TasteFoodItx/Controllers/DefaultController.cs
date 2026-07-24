using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodItx.Entities;
using TasteFoodItx.Context;
using System.Data.Entity;

namespace TasteFoodItx.Controllers
{
    public class DefaultController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbarInfo()
        {
            ViewBag.phone = context.Addresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.email = context.Addresses.Select(y => y.Email).FirstOrDefault();
            ViewBag.description = context.Addresses.Select(z => z.Description).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }


        public PartialViewResult PartialSlider()
        {
            var values = context.Sliders.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult PartialReservation()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult PartialReservation(Reservation reservation)
        {
            reservation.ReservationStatus = "Bekliyor";
            context.Reservations.Add(reservation);
            context.SaveChanges();

            TempData["RezervasyonSonuc"] = "Rezervasyonunuz başarıyla alınmıştır! Teşekkür ederiz.";

            return RedirectToAction("Index");
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.title = context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.image = context.Abouts.Select(x => x.ImageUrl).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult PartialMenu()
        {
            var values = context.Products
                .Include(x => x.Category)
                .Where(x => x.WindowState == true)
                .ToList();

            return PartialView(values);
        }


        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();

            return PartialView(values);   
        }

        public PartialViewResult PartialChef()
        {
            var values = context.Chefs.ToList();
            return PartialView(values);
        }


        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }






    }
}