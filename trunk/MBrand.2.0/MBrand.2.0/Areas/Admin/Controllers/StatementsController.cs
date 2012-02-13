using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBrand.Models;

namespace MBrand.Areas.Admin.Controllers
{
    public class StatementsController : Controller
    {
        ContentContainer context = new ContentContainer();

        public ActionResult Index()
        {
            return View(context.Statements);
        }

        public ActionResult Create()
        {
            return View("CreateEdit");
        }

        [HttpPost]
        public ActionResult Create(string text)
        {
            Statement statement = new Statement { Text = HttpUtility.HtmlDecode(text) };
            context.AddToStatements(statement);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View("CreateEdit", context.Statements.First(s => s.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, string text)
        {
            context.Statements.First(s => s.Id == id).Text = HttpUtility.HtmlDecode(text);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            context.DeleteObject(context.Statements.First(s => s.Id == id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
