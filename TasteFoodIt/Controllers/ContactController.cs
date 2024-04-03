using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Entities;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            string PageName = "İletişim";
            TempData["Page"] = PageName;
            return View();
        }

        public ActionResult PartialContactInformation()
        {
            return PartialView();
        }

        public ActionResult PartialContactUs()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult Add(Contact p)
        {
            if (ModelState.IsValid)
            {
                p.SendDate = DateTime.Now;
                p.IsRead = 0;
                var value = context.Contacts.Add(p);
                context.SaveChanges();
                return Json("OK"); // işlem başarılı gittinde OK yanıtı dönecek
            }
            return Json("Model validation failed.");
        }
    }
}