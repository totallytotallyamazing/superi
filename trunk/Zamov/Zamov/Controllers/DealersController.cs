using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;
using Zamov.Models;

namespace Zamov.Controllers
{
    public class DealersController : Controller
    {
        //
        // GET: /Dealers/

        public ActionResult Index()
        {
            List<int> dealersIds = new List<int>();
            List<Dealer> dealers = new List<Dealer>();
            using (ZamovStorage context = new ZamovStorage())
            {
                dealers = (from dealer in context.Dealers.Include("Cities").Include("Categories")
                                        where dealer.Cities.Where(c => c.Id == SystemSettings.CityId).Count() > 0
                                        && dealer.Categories.Where(c => c.Id == SystemSettings.CategoryId).Count() > 0
                                        select dealer).ToList();
            }
            
            return View(dealers);

        }

    }
}
