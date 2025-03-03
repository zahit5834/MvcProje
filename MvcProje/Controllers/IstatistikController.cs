using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        public ActionResult Index()
        {
            ViewBag.ToplamKategori = 5;
            ViewBag.EnCokBaslik = "Yazılım";
            ViewBag.YazarSayisi = 2;
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
    }
}