using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using PolialClean.Models;

namespace PolialClean.Controllers
{
    public class ClientsController : Controller
    {
        //
        // GET: /Clients/

        public ActionResult Index()
        {
            using (DataStorage context = new DataStorage())
            {
                List<Clients> clients = context.Clients.Select(c => c).ToList();
                return View(clients);
            }
        }

        public ActionResult Client(Clients client)
        {
            return View(client);
        }

        public ActionResult Recomendation(Recomendations recomendation, int count, int index)
        {
            ViewData["count"] = count;
            ViewData["index"] = index;
            return View(recomendation);
        }

        public ActionResult Object(Objects item)
        {
            return View(item);
        }
    }
}
