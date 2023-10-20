using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
	public class WriterController : Controller
	{
		// GET: Writer
		MvcKutuphaneEntities1 db = new MvcKutuphaneEntities1();
		public ActionResult Index()
		{
			var values = db.YAZAR.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult AddWritter()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddWritter(YAZAR y)
		{
			db.YAZAR.Add(y);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DeleteWritter(int id)
		{
			var yazar = db.YAZAR.Find(id);
			db.YAZAR.Remove(yazar);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult UpdateWriter(int id)
		{
			var yzr = db.YAZAR.Find(id);
			return View("UpdateWriter", yzr);
		}
		public ActionResult WriterUpdate(YAZAR p)
		{
			var yzr = db.YAZAR.Find(p.ID);
			yzr.AD = p.AD;
			yzr.SOYAD = p.SOYAD;
			yzr.DETAY = p.DETAY;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult MyBook(int id)
		{
			var writer = db.KITAP.Where(x => x.YAZAR == id).ToList();
			var yzrad = db.YAZAR.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
			ViewBag.yzr = yzrad;
			return View(writer);
		}
	}
}