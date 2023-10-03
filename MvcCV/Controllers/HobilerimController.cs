using MvcCV.Models.Entity;
using MvcCV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class HobilerimController : Controller
    {

        DbCVEntities db = new DbCVEntities();
        GenericRepository<TblHobilerim> hobirepo = new GenericRepository<TblHobilerim>();
        // GET: Hobilerim
        [HttpGet]
        public ActionResult Index()
        {
            var hobi = hobirepo.List();
            return View(hobi);
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim t)
        {
            var hobi = hobirepo.Find(x => x.ID == 1);
            hobi.Aciklama1 = t.Aciklama1;
            hobi.Aciklama2 = t.Aciklama2;
            hobirepo.TUpdate(hobi);
            return RedirectToAction("Index");
        }
    }
}