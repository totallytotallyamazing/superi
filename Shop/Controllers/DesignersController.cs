using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class DesignersController : Controller
    {
        //
        // GET: /Designers/

        public ActionResult Index(string id)
        {
            using (var context = new PortfolioStorage())
            {
                Portfolio portfolio = context.Portfolio.Include("PortfolioImage").First(p => p.Url == id);
                return View(portfolio);
            }
        }

    }
}
