using MvcKutuphane.Models.Class;
using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
	public class ShowcaseController : Controller
	{
		// GET: Showcase
		MvcKutuphaneEntities1 db = new MvcKutuphaneEntities1();
		[HttpGet]
		public ActionResult Index()
		{
			Class1 cs=new Class1();
			cs.Value1=db.KITAP.ToList();
			cs.Value2=db.HAKKIMIZDA.ToList();
			return View(cs);
		}
		[HttpPost]
		public ActionResult Index(ILETISIM t) 
		{
			db.ILETISIM.Add(t);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}