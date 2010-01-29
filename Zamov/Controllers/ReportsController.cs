using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.UI.WebControls;

namespace Zamov.Controllers
{

    [Authorize(Roles = "Administrators, Managers")]
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SalesReport(int? dealerId, string userName, string city, Statuses? orderState, string sortField, SortDirection? sortOrder)
        {
            HttpContext.Items["sortField"] = ViewData["sortField"] = sortField;
            SortDirection sortDirection = (sortOrder == SortDirection.Ascending || sortOrder == null) ? SortDirection.Ascending : SortDirection.Descending;
            HttpContext.Items["sortDirection"] = ViewData["sortDirection"] = sortDirection;

            using (Reports context = new Reports())
            {
                int? orderStatus = (orderState.HasValue) ? (int)orderState.Value : (int?)null;
                var orders = context.SalesReport.OrderBy(o=>o.OrderId)
                    .Where(o => (dealerId == null || o.DealerId == dealerId))
                    .Where(o => (userName == null || o.UserName == userName))
                    .Where(o => (city == null || o.City == city))
                    .Where(o => (orderStatus == null || o.Status == orderStatus))
                    .Select(o => o).ToList();

                if (!string.IsNullOrEmpty(sortField))
                {
                    int direction = (sortOrder == SortDirection.Ascending || sortOrder == null) ? direction = 1 : direction = -1;

                    orders.Sort(delegate(SalesReportItem a, SalesReportItem b)
                    {
                        return Utils.CompareObjectFields(a, b, sortField, direction);
                    });
                }

                return View(orders);
            }
        }

    }
}
