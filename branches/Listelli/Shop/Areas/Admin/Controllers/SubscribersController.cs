using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    public class SubscribersController : Controller
    {
        //
        // GET: /Admin/Subscribers/

        public ActionResult Index()
        {
            using (Clients context = new Clients())
            {
                var subscribers = context.Subscribers.ToList();
                return View(subscribers);
            }
        }

        public ActionResult Create()
        {
            return View(new Subscriber { IsActive=true});
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            using (Clients context = new Clients())
            {
                Subscriber subscriber = new Subscriber();

                TryUpdateModel(subscriber, new[] { "Email", "IsActive" });
                
                subscriber.UniqueId = new Guid();
                context.AddToSubscribers(subscriber);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            using (Clients context = new Clients())
            {
                Subscriber subscriber = context.Subscribers.Where(s => s.Email == id).FirstOrDefault();
                context.DeleteObject(subscriber);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            using (Clients context = new Clients())
            {
                Subscriber subscriber = context.Subscribers.Where(s => s.Email == id).FirstOrDefault();
                return View(subscriber);
            }
        }

        [HttpPost]
        public ActionResult Edit(string id, FormCollection form)
        {
            using (Clients context = new Clients())
            {
                Subscriber subscriber = context.Subscribers.Where(s => s.Email == id).FirstOrDefault();
                TryUpdateModel(subscriber, new[] { "Email" ,"IsActive"});
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
