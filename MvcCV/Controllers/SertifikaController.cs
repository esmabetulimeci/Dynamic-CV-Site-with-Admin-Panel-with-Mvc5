using MvcCV.Models.Entity;
using MvcCV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class SertifikaController : Controller
    {
        DbCVEntities db = new DbCVEntities();
        GenericRepository<TblSertifikalarım> sertifikarepo = new GenericRepository<TblSertifikalarım>();
        // GET: Sertifika
        public ActionResult Index()
        {
            var sertifika = sertifikarepo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaDüzenle(int id)
        {
            var sertifika = sertifikarepo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika); 
        }

        [HttpPost]
        public ActionResult SertifikaDüzenle(TblSertifikalarım t)
        {
            var sertifika = sertifikarepo.Find(x => x.ID == t.ID);
            sertifika.Aciklama=t.Aciklama;
            sertifika.Tarih = t.Tarih;
            sertifikarepo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarım p)
        {
            sertifikarepo.TAdd(p);
            return RedirectToAction("Index");
              
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = sertifikarepo.Find(x => x.ID == id);
            sertifikarepo.TDelete(sertifika);
            return RedirectToAction("Index");

        }

    }
}