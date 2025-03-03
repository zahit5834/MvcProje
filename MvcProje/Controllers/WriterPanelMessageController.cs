using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var p = (Writer)Session["WriterUserInfo"];
            var messageList = mm.GetListInbox(p.WriterMail);
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            var p = (Writer)Session["WriterUserInfo"];
            var messageList = mm.GetListSentBox(p.WriterMail);
            return View(messageList);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult result = messageValidator.Validate(p);
            if (result.IsValid)
            {
                var t = (Writer)Session["WriterUserInfo"];
                p.MessageDate = DateTime.Parse(DateTime.Now.ToString());
                p.SenderMail = t.WriterMail;
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }
        public ActionResult GetSendMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }
    }
}