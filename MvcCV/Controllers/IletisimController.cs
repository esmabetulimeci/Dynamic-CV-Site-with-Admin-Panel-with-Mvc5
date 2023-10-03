using MvcCV.Models.Entity;
using MvcCV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        DbCVEntities db = new DbCVEntities();
        GenericRepository<TblIletisim> iletisimrepo = new GenericRepository<TblIletisim>();
        public ActionResult Index()
        {
            var iletisim = iletisimrepo.List();
            return View();
        }
    }
}