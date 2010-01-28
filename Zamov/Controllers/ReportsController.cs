using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

namespace Zamov.Controllers
{
    class SalesReportItem
    { 
            
    }

    [Authorize(Roles = "Administrators, Managers")]
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SalesReport(int? dealerId, Guid? userId, string city, Statuses? orderState)
        {
            using (OrderStorage context = new OrderStorage())
            {
                //var orders = context.Orders
                //    .Join(
                //    .Where(o => (!dealerId.HasValue || o.Dealer.Id == dealerId))
                //    .Where(o => (!userId.HasValue || o.UserId == userId))
                //    .Where(o => (string.IsNullOrEmpty(city) || o.City == city))
                //    .Where(o => (!orderState.HasValue || o.Status == (int)orderState.Value)).Select(o => o);

                


                return View();
            }
        }

    }
}
