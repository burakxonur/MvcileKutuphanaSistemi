using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
	public class EmployeeController : Controller
	{
		// GET: Employee
		MvcKutuphaneEntities1 db = new MvcKutuphaneEntities1();
		public ActionResult Index()
		{
			var values = db.PERSONEL.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult AddEmployee()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddEmployee(PERSONEL p)
		{
			if (!ModelState.IsValid)
			{
				return View("AddEmployee");
			}
			db.PERSONEL.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DeleteEmployee(int id)
		{
			var employee = db.PERSONEL.Find(id);
			db.PERSONEL.Remove(employee);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult UpdateEmployee(int id)
		{
			var prs = db.PERSONEL.Find(id);
			return View("UpdateEmployee", prs);
		}
		public ActionResult EmployeeUpdate(PERSONEL p)
		{
			var personel = db.PERSONEL.Find(p.ID);
			personel.PERSONEL1 = p.PERSONEL1;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}