using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodItx.Context;
using TasteFoodItx.Entities;

namespace TasteFoodItx.Controllers
{
    public class AddressController : Controller
    {
        TasteContext context = new TasteContext();

        public ActionResult AddressList()
        {
            var values = context.Addresses.ToList();
            ViewBag.v = context.Addresses.Count();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAddress(Address address)
        {
            context.Addresses.Add(address);
            context.SaveChanges();

            return RedirectToAction("AddressList");
        }

        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var values = context.Addresses.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAddress(Address address)
        {
            var values = context.Addresses.Find(address.AddressId);
            values.Description = address.Description;
            values.Email = address.Email;
            values.Phone = address.Phone;

            context.SaveChanges();
            return RedirectToAction("AddressList");


        }










    }
}