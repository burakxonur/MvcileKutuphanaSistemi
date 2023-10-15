using MvcKutuphane.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MvcKutuphane.Controllers
{
	public class BookController : Controller
	{
		// GET: Book
		MvcKutuphaneEntities1 db = new MvcKutuphaneEntities1();
		public ActionResult Index(string p)
		{
			var books = from k in db.KITAP select k;
			if (!string.IsNullOrEmpty(p))
			{
				books = books.Where(x => x.AD.Contains(p));
			}

			//var books = db.KITAP.ToList();
			return View(books.ToList());
		}
		[HttpGet]
		public ActionResult AddBooks()
		{
			List<SelectListItem> value1 = (from i in db.KATEGORI.ToList()
										   select new SelectListItem
										   {
											   Text = i.AD,
											   Value = i.ID.ToString()
										   }).ToList();
			ViewBag.dgr1 = value1;

			List<SelectListItem> value2 = (from yz in db.YAZAR.ToList()
										   select new SelectListItem
										   {
											   Text = yz.AD + ' ' + yz.SOYAD,
											   Value = yz.ID.ToString()
										   }).ToList();
			ViewBag.dgr2 = value2;
			return View();
		}
		[HttpPost]
		public ActionResult AddBooks(KITAP p)
		{
			var ktg = db.KATEGORI.Where(k => k.ID == p.KATEGORI1.ID).FirstOrDefault();
			var yzr = db.YAZAR.Where(y => y.ID == p.YAZAR1.ID).FirstOrDefault();
			p.KATEGORI1 = ktg;
			p.YAZAR1 = yzr;
			db.KITAP.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");

		}
		public ActionResult DeleteBook(int id)
		{
			var ktp = db.KITAP.Find(id);
			db.KITAP.Remove(ktp);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult UpdateBook(int id)
		{
			var ktp = db.KITAP.Find(id);
			List<SelectListItem> value1 = (from i in db.KATEGORI.ToList()
										   select new SelectListItem
										   {
											   Text = i.AD,
											   Value = i.ID.ToString()
										   }).ToList();
			ViewBag.dgr1 = value1;

			List<SelectListItem> value2 = (from yz in db.YAZAR.ToList()
										   select new SelectListItem
										   {
											   Text = yz.AD + ' ' + yz.SOYAD,
											   Value = yz.ID.ToString()
										   }).ToList();
			ViewBag.dgr2 = value2;
			return View("UpdateBook", ktp);
		}
		public ActionResult BookUpdate(KITAP p)
		{
			var kitap = db.KITAP.Find(p.ID);
			kitap.AD = p.AD;
			kitap.BASIMYIL = p.BASIMYIL;
			kitap.SAYFA = p.SAYFA;
			kitap.YAYINEVI = p.YAYINEVI;
			kitap.DURUM = true;
			var ktg = db.KATEGORI.Where(k => k.ID == p.KATEGORI1.ID).FirstOrDefault();
			var yzr = db.YAZAR.Where(y => y.ID == p.YAZAR1.ID).FirstOrDefault();
			kitap.KATEGORI = ktg.ID;
			kitap.YAZAR = yzr.ID;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}