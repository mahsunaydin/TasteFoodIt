using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodItx.Context;

namespace TasteFoodItx.Controllers
{
    public class NotificationController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult NotificationList()
        {
            var values = context.Notifications.ToList();
            return View(values);
        }

        public ActionResult NotificationIsReadChangeStatus(int id)
        {
            var values = context.Notifications.Find(id);
            
            if(values.IsRead == true)
            {
                values.IsRead = false;
            }
            else
            {
                values.IsRead = true;
            }

            context.SaveChanges();

            return RedirectToAction("NotificationList");

        }





    }
}