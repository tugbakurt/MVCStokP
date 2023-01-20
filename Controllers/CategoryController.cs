﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        URUNSTOKPROJEDBEntities db = new URUNSTOKPROJEDBEntities();

        public ActionResult Index()
        {

            var degerler = db.TBL_kategoriler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCategory(TBL_kategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniCategory");
            }
            db.TBL_kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        { 
            var category = db.TBL_kategoriler.Find(id);
            db.TBL_kategoriler.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBL_kategoriler.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult Guncelle(TBL_kategoriler p1)
        {
            var ktg = db.TBL_kategoriler.Find(p1.kategoriid);
            ktg.kategoriad = p1.kategoriad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}