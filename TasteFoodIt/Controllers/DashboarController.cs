using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class DashboarController : Controller
    {
        TasteContext context = new TasteContext();
        
        public ActionResult DashboarList()
        {
            ViewBag.categoryCount = context.Categories.Count();
            ViewBag.productCount = context.Products.Count();
            ViewBag.chefCount = context.Chefs.Count();
            ViewBag.reservationCount = context.Reservations.Where(x => x.ReservationStatus == "onaylandi").Count();
            return View();
        }

        public ActionResult GrafikOlustur()
        {
            return Json(Rezervasyonlar(), JsonRequestBehavior.AllowGet);
        }

        public List<ReservationsChart> Rezervasyonlar()
        {
            return null;
        }
    }
}