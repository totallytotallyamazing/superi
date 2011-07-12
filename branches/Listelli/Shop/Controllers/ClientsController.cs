using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;
using System.Data.SqlClient;

namespace Shop.Controllers
{
    public class ClientsController : Controller
    {
        //
        // GET: /Clients/
        [HttpPost, OutputCache(NoStore=true, Duration=1, VaryByParam="*")]
        public void Subscribe(string id)
        {
            using (Clients context = new Clients())
            {
                try
                {
                    Subscriber subscriber = new Subscriber();
                    subscriber.Email = id;
                    subscriber.UniqueId = new Guid();
                    context.AddToSubscribers(subscriber);
                    context.SaveChanges();
                    Response.Write(0);
                }
                catch (UpdateException e)
                {
                    if (e.InnerException is SqlException)
                        Response.Write(1);
                    else
                        Response.Write(2);
                }
            }   
        }

        [HttpPost, OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public void UnSubscribe(string id)
        {
            using (Clients context = new Clients())
            {
                try
                {
                    Subscriber subscriber = context.Subscribers.Where(s => s.Email == id).FirstOrDefault();
                    if (subscriber == null)
                    {
                        Response.Write(1);
                    }
                    else
                    {
                        context.DeleteObject(subscriber);
                        context.SaveChanges();
                        Response.Write(0);
                    }
                }
                catch (UpdateException e)
                {
                    if (e.InnerException is SqlException)
                        Response.Write(1);
                    else
                        Response.Write(2);
                }
            }
        }

    }
}
