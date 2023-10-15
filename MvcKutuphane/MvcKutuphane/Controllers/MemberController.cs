using MvcKutuphane.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
	public class MemberController : Controller
	{
		// GET: Member
		MvcKutuphaneEntities1 db = new MvcKutuphaneEntities1();
		public ActionResult Index(int page = 1)
		{
			var values = db.UYELER.ToList().ToPagedList(page, 10);
			return View(values);
		}
		[HttpGet]
		public ActionResult AddMember()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddMember(UYELER p)
		{
			if (!ModelState.IsValid)
			{
				return View("AddMember");
			}
			db.UYELER.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DeleteMember(int id)
		{
			var member = db.UYELER.Find(id);
			db.UYELER.Remove(member);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult UpdateMember(int id)
		{
			var prs = db.UYELER.Find(id);
			return View("UpdateMember", prs);
		}
		public ActionResult MemberUpdate(UYELER p)
		{
			var uyeler = db.UYELER.Find(p.ID);
			uyeler.AD = p.AD;
			uyeler.SOYAD = p.SOYAD;
			uyeler.MAIL = p.MAIL;
			uyeler.KULLANICIADI = p.KULLANICIADI;
			uyeler.SIFRE = p.SIFRE;
			uyeler.FOTOGRAF = p.FOTOGRAF;
			uyeler.TELEFON = p.TELEFON;
			uyeler.OKUL = p.OKUL;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}