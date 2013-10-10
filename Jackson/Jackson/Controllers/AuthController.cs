using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Jackson.Controllers
{
    public class AuthController : Controller
    {
        //
        // GET: /Auth/

        public ActionResult Login()
        {
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel, string returnUrl)
        {
            if (FormsAuthentication.Authenticate(loginModel.Name, loginModel.Password))
            {
                FormsAuthentication.SetAuthCookie(loginModel.Name, loginModel.Keep);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            return View();

        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }

    public class LoginModel
    {

        public bool Keep { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
