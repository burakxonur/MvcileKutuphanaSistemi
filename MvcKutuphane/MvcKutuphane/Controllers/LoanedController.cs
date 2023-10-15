using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
	public class LoanedController : Controller
	{
		// GET: Loaned
		MvcKutuphaneEntities1 db = new MvcKutuphaneEntities1();
		public ActionResult Index()
		{
			var values = db.HAREKET.Where(x => x.ISLEMDURUM == false).ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult Lending()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Lending(HAREKET p)
		{
			db.HAREKET.Add(p);
			db.SaveChanges();
			return RedirectToAction("Lending");
		}
		public ActionResult LoanReturn(int id)
		{
			var odn = db.HAREKET.Find(id);
			return View("LoanReturn", odn);
		}
		public ActionResult UpdateLoan(HAREKET p)
		{
			var hrk = db.HAREKET.Find(p.ID);
			hrk.UYEGETIRTARIH = p.UYEGETIRTARIH;
			hrk.ISLEMDURUM = true;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}