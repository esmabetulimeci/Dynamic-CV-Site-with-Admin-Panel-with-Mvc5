using MvcCV.Models.Entity;
using MvcCV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class HakkımdaController : Controller
    {
        DbCVEntities db = new DbCVEntities();
        GenericRepository<TblHakkimda> hakkimdarepo = new GenericRepository<TblHakkimda>();
        // GET: Hobilerim
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = hakkimdarepo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TblHakkimda t)
        {
            var hakkimda = hakkimdarepo.Find(x => x.ID == 1);
            hakkimda.Ad = t.Ad;
            hakkimda.Soyad=t.Soyad;
            hakkimda.Adres = t.Adres;
            hakkimda.Mail=t.Mail;
            hakkimda.Telefon = t.Telefon;
            hakkimda.Resim=t.Resim;
            hakkimda.Aciklama=t.Aciklama;   
            hakkimdarepo.TUpdate(hakkimda);
            return RedirectToAction("Index");
        }
    }
}