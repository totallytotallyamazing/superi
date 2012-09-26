using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.ComponentModel.DataAnnotations;
using Shop.Helpers.Validation;
using Dev.Helpers;
using Dev.Mvc.Runtime;
using System.Net.Mail;
using System.ComponentModel;
using Superi.Web.Mvc.Localization;
using Shop.Resources;
using Shop.Helpers;

//using Superi.Web.Mvc.Localization;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        [Content(ContentName="Index")]
        public ActionResult Index()
        {
            //Don't deleate the following. Used as Localization reference.
            //using (ShopStorage context = new ShopStorage())
            //{
                //LocalResource res = new LocalResource();
                //res.EntityId = 1;
                //res.EntityName = "Product";
                //res.FieldName = "Name";
                //res.Language = "en-US";
                //res.Text = "bla-bla1";
                //LocalResource res1 = new LocalResource();
                //res1.EntityId = 2;
                //res1.EntityName = "Product";
                //res1.FieldName = "Name";
                //res1.Language = "en-US";
                //res1.Text = "bla-bla2";
                //LocalizationExtensions.SeveLocalization(new List<LocalResource> { res, res1 }, context.LocalResources); 
                //context.LocalResources.Where(l => l.EntityId == 1 && l.EntityName == "E1").GroupBy(l => l.Language, l => new KeyValuePair<string, string>(l.FieldName, l.Text)).ToList();
              //  context.Products.Localize((e, l) => new { e = e, l = l }, context.LocalResources);
                //context.Products.First().Localizations(context.LocalResources);

               // context.Products.Localize((e, l) => new { e = e, l = l.First() });
            //}
            ViewData["isHomePage"] = true;
            return View("Content");
        }


        [Content(ContentName = "Conditions")]
        public ActionResult Conditions()
        {

            return View("Content");
        }

        [Content(ContentName = "Fond")]
        public ActionResult Fond()
        {

            return View("Content");
        }

        [Content]
        public ActionResult Go(string id)
        {
            return View("Content");
        }

        [Content]
        public ActionResult ShowContent(string id)
        {
            return View();
        }

        public ActionResult FeedbackForm()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult FeedbackForm(FeedbackFormModel feedbackFormModel)
        {
            SiteSettings settings = Configurator.LoadSettings();
            //MailHelper.SendFeedbackTemplate(new List<MailAddress> { new MailAddress(settings.ReceiverMail), new MailAddress(settings.ReceiverMail2) }, "Форма обратной связи", "FeedbackTemplate.htm", null, true, feedbackFormModel.Name, feedbackFormModel.Email, feedbackFormModel.Text);
            MailHelper.SendFeedbackTemplate(new List<MailAddress> { new MailAddress("kushko.alex@gmail.com") }, "Форма обратной связи", "FeedbackTemplate.htm", null, true, feedbackFormModel.Name, feedbackFormModel.Email, feedbackFormModel.Text);
            return RedirectToAction("FeedbackSent");
        }

        public ActionResult FeedbackSent()
        {
            return View();
        }

        [OutputCache(NoStore = true, VaryByParam = "*", Duration = 1)]
        public ActionResult Map()
        {
            return View();
        }
    }
}

namespace Shop.Models
{
    public class FeedbackFormModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Global))]
        [LocalizedDisplayName("NameLastName", NameResourceType = typeof(Global))]
        public string Name { get; set; }
        [LocalizedDisplayName("Email", NameResourceType=typeof(Global))]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", 
            ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType=typeof(Global))]
        public string Email { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Global))]
        [LocalizedDisplayName("QueryText", NameResourceType=typeof(Global))]
        public string Text { get; set; }
        [Captcha("ValidateCaptcha", "Captcha", "value", ErrorMessageResourceName="InvalidCaptcha", ErrorMessageResourceType = typeof(Global))]
        [Required(ErrorMessageResourceName = "RequiredCaptcha", ErrorMessageResourceType = typeof(Global))]
        [DisplayName("")]
        public string Captcha { get; set; }
    }
}



