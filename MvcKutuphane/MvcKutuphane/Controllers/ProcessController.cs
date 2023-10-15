using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
	public class ProcessController : Controller
	{
		// GET: Process
		MvcKutuphaneEntities1 db = new MvcKutuphaneEntities1();
		public ActionResult Index()
		{
			var values=db.HAREKET.Where(x=>x.ISLEMDURUM==true).ToList();
			return View(values);
		}
	}
}