using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;


namespace MVCStok.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler

        URUNSTOKPROJEDBEntities db = new URUNSTOKPROJEDBEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_urunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBL_kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(TBL_urunler p1)
        {
            var ktg = db.TBL_kategoriler.Where(m => m.kategoriid == p1.TBL_kategoriler.kategoriid).FirstOrDefault();
            p1.TBL_kategoriler = ktg;
            db.TBL_urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.TBL_urunler.Find(id);
            db.TBL_urunler.Remove(urun);
            db.SaveChanges();
          return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urn = db.TBL_urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.TBL_kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir",urn);
        }
        public ActionResult Guncelle(TBL_urunler p)
        {
            var urun = db.TBL_urunler.Find(p.urunid);
            urun.urunad = p.urunad;
            urun.marka = p.marka;
            urun.fiyat = p.fiyat;
            // urun.urunkategori = p.urunkategori;
            var ktg = db.TBL_kategoriler.Where(m => m.kategoriid == p.TBL_kategoriler.kategoriid).FirstOrDefault();
            urun.urunkategori = ktg.kategoriid;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}