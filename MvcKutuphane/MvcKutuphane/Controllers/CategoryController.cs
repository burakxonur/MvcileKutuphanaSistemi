using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
	public class CategoryController : Controller
	{
		// GET: Category
		MvcKutuphaneEntities1 db = new MvcKutuphaneEntities1();
		public ActionResult Index()
		{
			var values = db.KATEGORI.Where(x => x.DURUM == true).ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult AddCategory()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddCategory(KATEGORI p)
		{
			db.KATEGORI.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DeleteCategory(int id)
		{
			var kategori = db.KATEGORI.Find(id);
			//db.KATEGORI.Remove(kategori);
			kategori.DURUM = false;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult UpdateCategory(int id)
		{
			var ktg = db.KATEGORI.Find(id);
			return View("UpdateCategory", ktg);
		}
		public ActionResult CategoryUpdate(KATEGORI p)
		{
			var ktg = db.KATEGORI.Find(p.ID);
			ktg.AD = p.AD;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}