using MvcCV.Models.Entity;
using MvcCV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class SosyalMedyaController : Controller
    {

        DbCVEntities db = new DbCVEntities();
        GenericRepository<TblSosyalMedya> sosyalrepo = new GenericRepository<TblSosyalMedya>();
        // GET: SosyalMedya
        public ActionResult Index()
        {
            var sosyalmedya = sosyalrepo.List();
            return View(sosyalmedya);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
        {
            sosyalrepo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Düzenle(int id)
        {
            var sosyalmedya = sosyalrepo.Find(x => x.ID == id);
            return View(sosyalmedya);
        }

        [HttpPost]
        public ActionResult Düzenle(TblSosyalMedya p)
        {
            var sosyalmedya = sosyalrepo.Find(x => x.ID == p.ID);
            sosyalmedya.ID= p.ID;
            sosyalmedya.Durum = true;
            sosyalmedya.Ad= p.Ad;
            sosyalmedya.Link=p.Link;
            sosyalmedya.Class= p.Class;
            sosyalrepo.TUpdate(sosyalmedya);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var sosyalmedya = sosyalrepo.Find(x => x.ID == id);
            sosyalmedya.Durum = false;
            sosyalrepo.TUpdate(sosyalmedya);
            return RedirectToAction("Index");

        }


    }
}