﻿using System;
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
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBL_musteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.mmusteriad.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBL_musteriler.ToList();
            //return View(degerler);
        }

        [HttpGet]

        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBL_musteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
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

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBL_musteriler.Find(id);
            return View("MusteriGetir",mus);
        }
        public ActionResult Guncelle(TBL_musteriler p1)
        {
            var mus = db.TBL_musteriler.Find(p1.musteriid);
            mus.mmusteriad = p1.mmusteriad;
            mus.musterisoyad = p1.musterisoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}