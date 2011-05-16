using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Helpers.Validation;
using System.Net.Mail;
using Dev.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MBrand.Models;

namespace MBrand.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult White(string redirectUrl)
        {
            HttpCookie blackCookie = Request.Cookies.Get("black");
            HttpCookie newCookie = new HttpCookie("black", "false");
            newCookie.Path = "/";
            newCookie.Expires = DateTime.Now.AddYears(1);
            if (blackCookie == null)
                Response.AppendCookie(newCookie);
            else
                Response.SetCookie(newCookie);
            return Redirect(redirectUrl);
        }

        public ActionResult Black(string redirectUrl)
        {
            HttpCookie blackCookie = Request.Cookies.Get("black");
            HttpCookie newCookie = new HttpCookie("black", "true");
            newCookie.Path = "/";
            newCookie.Expires = DateTime.Now.AddYears(1);
            if (blackCookie == null)
                Response.AppendCookie(newCookie);
            else
                Response.SetCookie(newCookie);
            return Redirect(redirectUrl);
        }

        public ActionResult SetCookie()
        {
            HttpCookie allow = new HttpCookie("allow");
            allow.Expires = DateTime.Now.AddYears(1);
            Response.AppendCookie(allow);
            return RedirectToAction("Index");
        }

        public ActionResult English(string redirectUrl)
        {
            ViewData["redirectUrl"] = redirectUrl;
            ViewData["english"] = true;
            return View();
        }

        public ActionResult FeedbackForm()
        {
            return View();
        }

        [HttpPost]
        public void FeedbackForm(FeedbackFormModel feedbackFormModel)
        {
            MailHelper.SendTemplate(new List<MailAddress> { new MailAddress("miller.kak.miller@gmail.com") },
                "Форма обратной связи", "FeedbackTemplate.htm",
                null, true, feedbackFormModel.Name, feedbackFormModel.Email, feedbackFormModel.Text);
            Response.Write("<script>window.top.$.fancybox.close()</script>");
        }
    }
}

namespace MBrand.Models
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
        [Captcha("ValidateCaptcha", "Captcha", "value", ErrorMessage = "Неправильные символы!")]
        [Required(ErrorMessage = "Введите символы с картинки")]
        [DisplayName("")]
        public string Captcha { get; set; }
    }
}
