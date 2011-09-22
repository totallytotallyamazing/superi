using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Dev.Mvc.Helpers;
using System.IO;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class CatalogsController : Controller
    {
        //
        // GET: /Admin/Catalogs/

        public ActionResult Index()
        {
            using (var context = new BrandCatalogStorage())
            {
                var catalogs = context.BrandCatalogCategory.Include("BrandCatalogFile").ToList();

                return View(catalogs);
            }
        }

        [HttpPost]
        public ActionResult CreateNewCatalog(FormCollection form)
        {
            if (!string.IsNullOrEmpty(form["Title"]))
            using (var context = new BrandCatalogStorage())
            {
                var catalog = new BrandCatalogCategory
                {
                    Title = form["Title"]
                };
                context.AddToBrandCatalogCategory(catalog);
                context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCatalog(int id)
        {
            using (var context = new BrandCatalogStorage())
            {
                var catalog = context.BrandCatalogCategory.Include("BrandCatalogFile").Where(c => c.Id == id).First();

                while (catalog.BrandCatalogFile.Any())
                {
                    var file = catalog.BrandCatalogFile.First();
                    IOHelper.DeleteFile("~/Content/BrandCatalogFiles", file.FileName);
                    context.DeleteObject(file);
                }
                context.DeleteObject(catalog);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult AddFileToCatalog(int catalogId, FormCollection form)
        {
            if (!string.IsNullOrEmpty(form["FileTitle"]))
            using (var context = new BrandCatalogStorage())
            {

                if (Request.Files["logo"] != null && !string.IsNullOrEmpty(Request.Files["logo"].FileName))
                {
                    var catalog = context.BrandCatalogCategory.Include("BrandCatalogFile").Where(c => c.Id == catalogId).First();

                    string fileName = IOHelper.GetUniqueFileName("~/Content/BrandCatalogFiles", Request.Files["logo"].FileName);
                    string filePath = Server.MapPath("~/Content/BrandCatalogFiles");
                    filePath = Path.Combine(filePath, fileName);
                    Request.Files["logo"].SaveAs(filePath);

                    var file = new BrandCatalogFile
                    {
                        FileName = fileName,
                        Title=form["FileTitle"],
                        BrandCatalogCategory = catalog
                    };


                    context.AddToBrandCatalogFile(file);
                    context.SaveChanges();
                }
            }


            return RedirectToAction("Index");
        }


        public ActionResult DeleteCatalogFile(int id)
        {
            using (var context = new BrandCatalogStorage())
            {
                var file = context.BrandCatalogFile.Where(c => c.Id == id).First();
                IOHelper.DeleteFile("~/Content/BrandCatalogFiles", file.FileName);
                context.DeleteObject(file);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
