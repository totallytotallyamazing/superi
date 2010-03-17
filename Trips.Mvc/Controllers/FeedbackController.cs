using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Helpers;
using System.Net.Mail;
using Trips.Mvc.Runtime;
using System.Text;

namespace Trips.Mvc.Controllers
{
    public class FeedbackController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [CaptchaValidation("captchaBox")]
        public ActionResult SendMessage(string name, string email, string message, bool captchaValid)
        {
            if (!captchaValid)
                throw new HttpException(404, "Captcha validationFailed");

            List<MailAddress> to = new List<MailAddress>();
            to.Add(new MailAddress(Configurator.GetSetting("ReceiverMail")));

            StringBuilder body = new StringBuilder();
            
            body.Append(message);
            body.Append(Environment.NewLine);
            body.Append(Environment.NewLine);
            body.Append(name);
            body.Append(email);
            
            string subject = "Ќа сайте trips.kiev.ua была заполнена форма обратной св€зи";

            MailHelper.SendMessage("mailinator@trips.kiev.ua", to, body.ToString(), subject, false);
            return Json(true);
        }

        public ActionResult MessageSent()
        {
            return View();
        }
    }
}
