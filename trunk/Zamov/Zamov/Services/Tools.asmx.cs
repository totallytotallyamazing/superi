using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Zamov.Models;
using Zamov.Controllers;
using Zamov.Helpers;

namespace Zamov.Services
{
    /// <summary>
    /// Summary description for Tools
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Tools : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public object GetCityCategories(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                List<Category> categories = context.GetCachedCategories(id, false);
                var result = (from category in categories select new {Selected = category.Id == SystemSettings.CategoryId, Text = category.GetName(SystemSettings.CurrentLanguage), Value = category.Id });
                return result;
            }
        }
        
        
        [WebMethod(EnableSession = true)]
        public object GetNewOrders(DateTime requestTime)
        {
            using (OrderStorage context = new OrderStorage())
            {
                DateTime lasttime = SystemSettings.LastTime;
                SystemSettings.LastTime = DateTime.Now;
                List<Order> orders = (
                                         from order in
                                             context.Orders.Include("Dealer")
                                         where order.Dealer.Id == SystemSettings.CurrentDealer && order.Date > lasttime
                                         select order ).ToList();

                var result = (from order in orders
                              select
                                  new
                                      {
                                          Id = order.Id,
                                          DeliveryDate = String.Format("{0:g}", order.DeliveryDate),
                                          ClientName = order.ClientName,
                                          Address = order.Address,
                                          Status = Controllers.Resources.GetResourceString("Status" + (Statuses)order.Status)
                                      });
                return result;
            }
        }
        


       


    }
}
