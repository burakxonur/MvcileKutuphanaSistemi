using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
	public class RegisterController : Controller
	{
		// GET: Register
		MvcKutuphaneEntities1 db = new MvcKutuphaneEntities1();
		[HttpGet]
		public ActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public ActionResult SignUp(UYELER p)
		{
			if (!ModelState.IsValid)
			{
				return View("SignUp");
			}
			db.UYELER.Add(p);
			db.SaveChanges();

			return View();
		}
	}
}