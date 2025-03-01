using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AdminContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactResult(int id)
        {
            var contactValue = cm.GetById(id);
            return View(contactValue);
        }
        public PartialViewResult MessageListMenu()
        {
            ViewBag.Sc = mm.GetListSentBox().Count();
            ViewBag.Ic = mm.GetListInbox().Count();
            ViewBag.cc = cm.GetList().Count();
            return PartialView();
        }
    }
}