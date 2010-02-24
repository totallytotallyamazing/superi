using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Helpers;
using System.Net.Mail;

namespace Dev.Controllers
{
    public class ToolsController : Controller
    {
        [CaptchaValidation("captchaBox")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SendMail(string name, string email, string message, bool captchaValid)
        {
            if (!captchaValid)
                return Json(false);
            else
            {
                string body = message + Environment.NewLine + Environment.NewLine + name + Environment.NewLine + email;
                MailHelper.SendMessage("production@elena-finger.com", new List<System.Net.Mail.MailAddress> { new MailAddress("production@elena-finger.com") }, body, "Ќа сайте elena-finger.com была заполнена форма обратной св€зи", false);
                return Json(true);
            }
        }
    }
}
