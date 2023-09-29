using MvcCV.Models.Entity;
using MvcCV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository deneyimrepo = new DeneyimRepository();
        public ActionResult Index()
        {
            var result = deneyimrepo.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimler p)
        {
            deneyimrepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimler t = deneyimrepo.Find(x => x.ID == id);
            deneyimrepo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyimler t = deneyimrepo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]

        public ActionResult DeneyimGetir(TblDeneyimler p)
        {
            TblDeneyimler t = deneyimrepo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = t.AltBaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            deneyimrepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}