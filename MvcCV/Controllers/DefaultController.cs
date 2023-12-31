﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities db = new DbCVEntities();
        public ActionResult Index()
        {
            var hakkimda = db.TblHakkimda.ToList();
            return View(hakkimda);
        }

        public ActionResult SosyalMedya()
        {
            var sosylmedya = db.TblSosyalMedya.Where(x => x.Durum == true).ToList();
            return PartialView(sosylmedya);
        }

        public PartialViewResult Deneyim() //PartialViewResult büyük görünümleri küçük bileşenlere ayırır.
        {
            var deneyimler = db.TblDeneyimler.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitim()
        {
            var egitimler = db.TblEgitim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yetenekler()
        {
            var yetenekler = db.TblYetenek.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobilerim()
        {
            var hobilerim = db.TblHobilerim.ToList();
            return PartialView(hobilerim);
        }

        public PartialViewResult Sertifikalar()
        {
            var sertifikalar = db.TblSertifikalarım.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult Iletişim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletişim(TblIletisim t)
        {
            t.Traih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblIletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}