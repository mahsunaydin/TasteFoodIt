﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TasteFoodIt.Controllers
{
    public class ProfileController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.V = Session["a"];
            return View();
        }
    }
}