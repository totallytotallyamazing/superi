using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trips.Mvc.Models;
using System.Web.UI;

namespace Trips.Mvc.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEditBrand(int? id)
        {
            ViewData["id"] = id;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddEditBrand(int? id, string name)
        {
            using (CarAdStorage context = new CarAdStorage())
            {
                Brand brand = null;
                if (id != null)
                {
                    brand = new Brand();
                    context.AddToBrands(brand);
                }
                brand.Name = name;
                context.SaveChanges();
            }
            return View();
        }

        public ActionResult Brands()
        {
            using (CarAdStorage context = new CarAdStorage())
            {
                List<Brand> brands = context.Brands.ToList();
                return View(brands);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddBrand(string name, bool published)
        {
            using (CarAdStorage context = new CarAdStorage())
            {
                Brand brand = new Brand();
                brand.Name = name;
                brand.Published = published;
                context.AddToBrands(brand);
                context.SaveChanges();
            }
            return RedirectToAction("Brands");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateBrand(int id, string name, bool published)
        {
            using (CarAdStorage context = new CarAdStorage())
            {
                Brand brand = context.Brands.Where(b => b.Id == id).First();
                brand.Name = name;
                brand.Published = published;
                context.SaveChanges();
            }
            return RedirectToAction("Brands");
        }

        private void DeleteImage(string name)
        {
            string imagePath = Server.MapPath("~/Content/AdImages/" + name);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        public ActionResult DeleteBrand(int id)
        {
            using (CarAdStorage context = new CarAdStorage())
            {
                Brand brand = context.Brands.Include("CarAds").Where(b => b.Id == id).First();
                foreach (var item in brand.CarAds)
                {
                    item.Images.Load();
                    foreach (var image in item.Images)
                    {
                        DeleteImage(image.ImageSource);
                        context.DeleteObject(image);
                    }
                    item.CarAdDescriptions.Load();
                    foreach (var description in item.CarAdDescriptions)
                    {
                        context.DeleteObject(description);
                    }
                    context.DeleteObject(item);
                }
                context.DeleteObject(brand);
                context.SaveChanges();
            }

            return RedirectToAction("Brands");
        }

        public ActionResult AddEditCarAd(int? id)
        {
            ViewData["id"] = id;

            List<SelectListItem> classes = new List<SelectListItem>
            {
                new SelectListItem{ Text = "Стандарт", Value="1"},
                new SelectListItem{ Text = "Средний", Value="2"},
                new SelectListItem{ Text = "Бизнес", Value="3"},
                new SelectListItem{ Text = "Минивены", Value="4"},
                new SelectListItem{ Text = "Мультивены", Value="5"},
            };

            CarAd carAd = new CarAd();

            using (CarAdStorage context = new CarAdStorage())
            {
                var brandsQuery = context.Brands
                    .OrderBy(br => br.Name)
                    .Select(br => new
                    {
                        Text = br.Name,
                        Value = br.Id
                    }).ToList();

                List<SelectListItem> brands = brandsQuery
                    .Select(br => new SelectListItem
                    {
                        Text = br.Text,
                        Value = br.Value.ToString()
                    }).ToList();

                if (id.HasValue)
                {
                    carAd = context.CarAds.Include("Brand").Include("CarAdDescriptions").Where(ca => ca.Id == id.Value).First();
                    ViewData["model"] = carAd.Model;
                    brands.ForEach(br => br.Selected = (int.Parse(br.Value) == carAd.Brand.Id));
                    classes.ForEach(cl => cl.Selected = (long.Parse(cl.Value) == carAd.Class));
                    Dictionary<string, string> descriptions = carAd.CarAdDescriptions.ToDictionary(cad=>cad.Language, cad=>cad.Text);
                    ViewData["description_ru"] = descriptions["ru-RU"];
                    ViewData["description_en"] = descriptions["en-US"];
                }

                ViewData["brands"] = brands;
                ViewData["classes"] = classes;
            }
            return View(carAd);
        }
    }
}
