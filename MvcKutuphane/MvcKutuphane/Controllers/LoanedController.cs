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
		public ActionResult LoanReturn(HAREKET p)
		{
			var odn = db.HAREKET.Find(p.ID);
			DateTime d1 = DateTime.Parse(odn.IADETARIH.ToString());
			DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			TimeSpan d3 = d2 - d1;
			ViewBag.dgr = d3.TotalDays;
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