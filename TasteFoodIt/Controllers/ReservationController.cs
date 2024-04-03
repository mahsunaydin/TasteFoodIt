using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ReservationController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult ReservationList()
        {
            var values = context.Reservations.OrderByDescending(x => x.ReservationDate).ToList();
            return View(values);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult CreateReservation()
        {
            return View();

        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult CreateReservation(Reservation p)
        {
            p.ReservationStatus = "beklemede";
            context.Reservations.Add(p);
            context.SaveChanges();
            return Json(p, JsonRequestBehavior.AllowGet);
        }

        //Rezervasyon Onaylama
        public ActionResult AcceptReservation(int id)
        {
            var values = context.Reservations.Find(id);
            values.ReservationStatus = "onaylandi";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        //Rezervasyon Bekletme
        public ActionResult WaitReservation(int id)
        {
            var values = context.Reservations.Find(id);
            values.ReservationStatus = "beklemede";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        //Rezervasyon İptal Etme
        public ActionResult CancelReservation(int id)
        {
            var values = context.Reservations.Find(id);
            values.ReservationStatus = "iptal";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        //Rezervasyonu Sil
        public ActionResult DeleteReservation(int id)
        {
            var values = context.Reservations.Find(id);
            context.Reservations.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        //Rezervasonu Güncelle
        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var values = context.Reservations.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateReservation(Reservation p)
        {
            var values = context.Reservations.Find(p.ReservationId);
            values.ReservationStatus = p.ReservationStatus;
            values.Name = p.Name;
            values.Phone = p.Phone;
            values.Email = p.Email;
            values.ReservationDate = p.ReservationDate;
            values.Time = p.Time;
            values.GuestCount = p.GuestCount;
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
    }
}