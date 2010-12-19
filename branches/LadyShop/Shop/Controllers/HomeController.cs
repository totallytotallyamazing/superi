using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.ComponentModel.DataAnnotations;
using Shop.Helpers.Validation;
using Dev.Helpers;
using Trips.Mvc.Runtime;
using System.Net.Mail;
using System.ComponentModel;

namespace Shop.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        [Content(ContentName = "home")]
        public ActionResult Index()
        {
            return View("Content");
        }

        [Content]
        public ActionResult Go(string id)
        {
            return View("Content");
        }

        //[ChildActionOnly]
        //public ActionResult Categories()
        //{
        //    using (ShopStorage context = new ShopStorage())
        //    {
        //        List<Category> categories = context.Categories.Include("Categories").Where(c => c.Parent == null).ToList();
        //        return View(categories);
        //    }
        //}

        public ActionResult FeedbackForm()
        {

            return View();
        }

        [HttpPost]
        public void FeedbackForm(FeedbackFormModel feedbackFormModel)
        {
            SiteSettings settings = Configurator.LoadSettings();
            MailHelper.SendTemplate(new List<MailAddress> { new MailAddress(settings.ReceiverMail) }, 
                "Форма обратной связи", "FeedbackTemplate.htm", 
                null, true, feedbackFormModel.Name, feedbackFormModel.Email, feedbackFormModel.Text);
            Response.Write("<script>window.top.$.fancybox.close()</script>");
        }
    }
}

namespace Shop.Models
{
    public class FeedbackFormModel
    {
        [Required(ErrorMessage = "Обязательно!")]
        [DisplayName("Имя, фамилия")]
        public string Name { get; set; }
        [DisplayName("Электропочта")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Неверно введен адрес почты. Формат: name@domain.com")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Обязательно!")]
        [DisplayName("Текст запроса")]
        public string Text { get; set; }
        [Captcha("ValidateCaptcha", "Captcha", "value", ErrorMessage="Неправильно введены символы с картинки!")]
        [Required(ErrorMessage = "Введите символы с картинки")]
        [DisplayName("")]
        public string Captcha { get; set; }
    }
}
