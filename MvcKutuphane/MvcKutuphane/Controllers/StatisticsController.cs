using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
	public class StatisticsController : Controller
	{
		// GET: Statistics
		MvcKutuphaneEntities1 db = new MvcKutuphaneEntities1();
		public ActionResult Index()
		{
			var values1 = db.UYELER.Count();
			ViewBag.dgr1 = values1;

			var values2 = db.KITAP.Count();
			ViewBag.dgr2 = values2;

			var values3 = db.KITAP.Where(x => x.DURUM == false).Count();
			ViewBag.dgr3 = values3;

			var values4 = db.CEZALAR.Sum(x => x.PARA);
			ViewBag.dgr4 = values4;
			return View();
		}
	}
}