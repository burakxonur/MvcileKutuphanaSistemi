﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class MyPanelController : Controller
    {
        // GET: MyPanel
       
        public ActionResult Index()
        {
            return View();
        }
    }
}