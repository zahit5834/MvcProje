using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    public class LoginController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var adminUserInfo = am.GetAdmin(p);
            if (adminUserInfo != null && adminUserInfo.Count >0)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo[0].AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo[0].AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            var writerUserInfo = wm.GetWriter(p);
            if (writerUserInfo != null && writerUserInfo.Count > 0)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo[0].WriterMail, false);
                Session["WriterMail"] = writerUserInfo[0].WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
    }
}