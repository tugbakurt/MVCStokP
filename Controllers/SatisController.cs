using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        URUNSTOKPROJEDBEntities db = new URUNSTOKPROJEDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]

        public ActionResult YeniSatis(TBL_satislar p)
        {
            db.TBL_satislar.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}