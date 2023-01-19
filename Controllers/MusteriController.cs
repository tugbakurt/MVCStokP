using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;
namespace MVCStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        URUNSTOKPROJEDBEntities db = new URUNSTOKPROJEDBEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_musteriler.ToList();
            return View(degerler);
        }

        [HttpGet]

        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBL_musteriler p1)
        {

            db.TBL_musteriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.TBL_musteriler.Find(id);
            db.TBL_musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}