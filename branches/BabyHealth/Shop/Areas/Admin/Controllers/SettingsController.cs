using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trips.Mvc.Runtime;

namespace Shop.Areas.Admin.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Admin/Settings/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(decimal euroRate, decimal dollarRate, decimal rubleRate, string receiverMail, int pageSize    )
        {

            Configurator.SetSetting("EuroRate", euroRate.ToString(CultureInfo.InvariantCulture));
            Configurator.SetSetting("DollarRate", dollarRate.ToString(CultureInfo.InvariantCulture));
            Configurator.SetSetting("RubleRate", rubleRate.ToString(CultureInfo.InvariantCulture));
            Configurator.SetSetting("ReceiverMail", receiverMail);
            Configurator.SetSetting("PageSize", pageSize.ToString(CultureInfo.InvariantCulture));
            return RedirectToAction("Index");
        }

    }
}
