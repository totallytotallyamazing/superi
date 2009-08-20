using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.Security;

namespace Zamov.Controllers
{
    public class FeedbackController : Controller
    {
        //
        // GET: /Feedback/

        private List<FeedbackPresentation> GetFeedbacks(int dealerId)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                List<FeedbackPresentation> feedbacks = (from feedback in context.DealerFeedback.Include("Dealer")
                                                        where feedback.Dealer.Id == dealerId
                                                        select new FeedbackPresentation
                                                        {
                                                            Text = feedback.Text,
                                                            Email = feedback.Email,
                                                            FirstName = feedback.FirstName,
                                                            Id = feedback.Id
                                                        }).ToList();
                return feedbacks;
            }
        }

        public ActionResult Index(int id)
        {
            List<FeedbackPresentation> feedbacks = GetFeedbacks(id);
            return View(feedbacks);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult ModifyFeedback(int id)
        {
            List<FeedbackPresentation> feedbacks = GetFeedbacks(id);
            return View(feedbacks);
        }

        [Authorize]
        [CaptchaValidation("captcha")]
        public ActionResult CreateFeedback(string text, bool captchaValid)
        {
            if (!captchaValid)
                return Json(false);
            else
            {
                DealerFeedback feedback = new DealerFeedback();
                ProfileCommon profile = ProfileCommon.Create(User.Identity.Name);
                MembershipUser user = Membership.GetUser();
                feedback.Text = text;
                feedback.UserId = (Guid)user.ProviderUserKey;
                feedback.FirstName = profile.FirstName;
                feedback.Email = user.Email;
                using (ZamovStorage context = new ZamovStorage())
                {
                    context.AddToDealerFeedback(feedback);
                    context.SaveChanges();
                }
                return Json(true);
            }
        }
    }
}
