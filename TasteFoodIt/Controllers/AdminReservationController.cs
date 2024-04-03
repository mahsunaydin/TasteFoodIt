using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminReservationController : Controller
    {
        TasteContext context = new TasteContext();

        [Authorize]
        public ActionResult ReservationList()
        {
            var values = context.Reservations.ToList();
            return View(values);
        }

        public ActionResult DeleteReservation(int id)
        {
            var values = context.Reservations.Find(id);
            values.ReservationStatus = "İptal Edildi";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        public ActionResult WaitReservation(int id)
        {
            var values = context.Reservations.Find(id);
            values.ReservationStatus = "Bekliyor";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var values = context.Reservations.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateReservation(Reservation r)
        {
            var values = context.Reservations.Find(r.ReservationId);
            values.ReservationStatus = r.ReservationStatus;
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }










    }
}