using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repository;

namespace MvcCV.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        DbCVEntities db = new DbCVEntities();
        GenericRepository<TblYetenek> repo = new GenericRepository<TblYetenek>();
        public ActionResult Index()
        {
            var yetenek = repo.List();
            return View(yetenek);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYetenek p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGüncelle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
         
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekGüncelle(TblYetenek t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Yetenek = t.Yetenek;
            y.Oran = t.Oran;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}