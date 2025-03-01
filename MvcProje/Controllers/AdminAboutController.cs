using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AdminAboutController : Controller
    {
        // GET: AdminAbout
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult EnableAbout(int id)
        {
            var aboutValue = abm.GetById(id);
            abm.AboutUpdate(aboutValue);
            return RedirectToAction("Index");
        }
        public ActionResult DisableAbout(int id)
        {
            var aboutValue = abm.GetById(id);
            abm.AboutDelete(aboutValue);
            return RedirectToAction("Index");
        }
    }
}