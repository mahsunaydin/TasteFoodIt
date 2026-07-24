using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodItx.Context;

namespace TasteFoodItx.Controllers
{
    public class ReservationController : Controller
    {
        TasteContext context = new TasteContext();

        public ActionResult ReservationList()
        {
            var values = context.Reservations.ToList();
            return View(values);
        }


        public ActionResult ChangeStatusByWaiting(int id)
        {
            var values = context.Reservations.Find(id);
            values.ReservationStatus = "Bekliyor";

            context.SaveChanges();

            return RedirectToAction("ReservationList");
        }

        public ActionResult ChangeStatusByCancel(int id)
        {
            var values = context.Reservations.Find(id);
            values.ReservationStatus = "İptal";

            context.SaveChanges();

            return RedirectToAction("ReservationList");
        }

        public ActionResult ChangeStatusByApprove(int id)
        {
            var values = context.Reservations.Find(id);
            values.ReservationStatus = "Onaylandı";

            context.SaveChanges();

            return RedirectToAction("ReservationList");
        }



















    }
}