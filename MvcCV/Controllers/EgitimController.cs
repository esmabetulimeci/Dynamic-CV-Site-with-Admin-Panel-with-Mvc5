using MvcCV.Models.Entity;
using MvcCV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class EgitimController : Controller
    {

        DbCVEntities db = new DbCVEntities();
        GenericRepository<TblEgitim> egitimrepo = new GenericRepository<TblEgitim>();
        // GET: Egitim

        [Authorize]
        public ActionResult Index()
        {
            var egitim = egitimrepo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            egitimrepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = egitimrepo.Find(x => x.ID == id);
            egitimrepo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDüzenle(int id)
        {
            var egitim = egitimrepo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDüzenle(TblEgitim t)
        {
            var egitim = egitimrepo.Find(x => x.ID == t.ID);
            egitim.Baslik = t.Baslik;
            egitim.AltBaslik1 = t.AltBaslik1;
            egitim.AltBaslik2 = t.AltBaslik2;
            egitim.GNO=t.GNO;
            egitim.Tarih = t.Tarih;
            egitimrepo.TUpdate(egitim);
            return RedirectToAction("Index");
            

        }
    }
}