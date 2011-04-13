using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    public class PortfolioController : Controller
    {
        //
        // GET: /Admin/Portfolio/

        public ActionResult Index()
        {
            using (var context = new PortfolioStorage())
            {
                var portfolios = context.Portfolio.Select(p => p).ToList();
                return View(portfolios);
            }
        }

        [OutputCache(VaryByParam = "*", NoStore = true, Duration = 1)]
        public ActionResult AddEdit(int? id)
        {
            Portfolio portfolio = null;
            if (id.HasValue)
            {
                using (var context = new PortfolioStorage())
                {
                    portfolio = context.Portfolio.First(p => p.Id == id.Value);
                }
            }
            return View(portfolio);
        }

        [HttpPost]
        public ActionResult AddEdit(FormCollection form)
        {
            using (var context = new PortfolioStorage())
            {
                int id;
                Portfolio portfolio;
                if (int.TryParse(form["Id"], out id))
                    portfolio = context.Portfolio.First(p => p.Id == id);
                else
                {
                    portfolio = new Portfolio();
                    context.AddToPortfolio(portfolio);
                }
                TryUpdateModel(portfolio, new string[] { "UserName" }, form.ToValueProvider());

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
