using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Dev.Helpers;
using MBrand.Helpers;
using MBrand.Models;
using MBrand.Models.MBrand.Models;

namespace MBrand.Controllers
{
    public class HomeController : Controller
    {
        ContentContainer context = new ContentContainer();
        public ActionResult Index()
        {

            return View();
        }

        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public PartialViewResult Start()
        {
            return PartialView(context.Statements);
        }

        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public PartialViewResult Contacts()
        {
            return PartialView();
        }

        public PartialViewResult SecretLink()
        {
            return PartialView();
        }

        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public PartialViewResult Feedback()
        {
            return PartialView();
        }

        [HttpPost,CaptchaValidation("Captcha")]
        public JsonResult Feedback(FormCollection form, bool captchaValid)
        {
            FeedbackFormModel feedbackFormModel = new FeedbackFormModel();

            feedbackFormModel.Email = form["Email"];
            feedbackFormModel.Name = form["Name"];
            feedbackFormModel.Text = form["Text"];
            if(captchaValid)
            {
                MailHelper.SendTemplate(new List<MailAddress> { new MailAddress("miller.kak.miller@gmail.com") }, "Форма обратной связи", "FeedbackTemplate.htm", null, true, feedbackFormModel.Name, feedbackFormModel.Email, feedbackFormModel.Text);
            }
            return Json(captchaValid);
        }

         override protected void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
