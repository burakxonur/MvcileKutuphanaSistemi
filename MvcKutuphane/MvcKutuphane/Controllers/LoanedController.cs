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
			List<SelectListItem> value1 = (from x in db.UYELER.ToList()
										   select new SelectListItem
										   {
											   Text = x.AD + " " + x.SOYAD,
											   Value = x.ID.ToString()
										   }).ToList();
			ViewBag.dgr1 = value1;

			List<SelectListItem> value2 = (from y in db.KITAP.Where(x => x.DURUM == true).ToList()
										   select new SelectListItem
										   {
											   Text = y.AD,
											   Value = y.ID.ToString()
										   }).ToList();
			ViewBag.dgr2 = value2;

			List<SelectListItem> value3 = (from p in db.PERSONEL.ToList()
										   select new SelectListItem
										   {
											   Text = p.PERSONEL1,
											   Value = p.ID.ToString()
										   }).ToList();
			ViewBag.dgr3 = value3;
			return View();
		}
		[HttpPost]
		public ActionResult Lending(HAREKET p)
		{
			var d1 = db.UYELER.Where(x => x.ID == p.UYELER.ID).FirstOrDefault();
			var d2 = db.KITAP.Where(y => y.ID == p.KITAP1.ID).FirstOrDefault();
			var d3 = db.PERSONEL.Where(z => z.ID == p.PERSONEL1.ID).FirstOrDefault();
			p.UYELER = d1;
			p.KITAP1 = d2;
			p.PERSONEL1 = d3;
			db.HAREKET.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
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