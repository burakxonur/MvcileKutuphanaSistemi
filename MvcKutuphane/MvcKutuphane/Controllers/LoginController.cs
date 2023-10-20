using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
	public class LoginController : Controller
	{
		// GET: Login
		MvcKutuphaneEntities1 db = new MvcKutuphaneEntities1();
		public ActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Login(UYELER p)
		{
			var informations = db.UYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
			if (informations != null)
			{
				FormsAuthentication.SetAuthCookie(informations.MAIL, false);
				Session["Ad"] = informations.AD.ToString();
				return RedirectToAction("Index", "MyPanel");
			}
			else
			{
				return View();
			}
		}
	}
}