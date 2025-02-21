using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AdminContentController : Controller
    {
        // GET: AdminContent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {

            return View();
        }
    }
}