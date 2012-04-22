using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dev.Helpers;

namespace MBrand.Controllers
{
    public class CaptchaController : Controller
    {
        public void Draw()
        {
            Response.Write(CaptchaExtensions.CaptchaImage(200, 60));
        }

        [OutputCache(NoStore=true, Duration=1, VaryByParam="*")]
        public void DrawAsync()
        {
            Response.Write(CaptchaExtensions.CaptchaImage(200, 60));
        }


        [CaptchaValidation("value")]
        public string ValidateCaptcha(bool captchaValid)
        {
            return (captchaValid) ? "true" : "false";
        }
    }
}
