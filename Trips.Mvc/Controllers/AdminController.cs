using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trips.Mvc.Models;
using System.Web.UI;
using System.Data;
using Trips.Mvc.Helpers;
using System.IO;
using Dev.Helpers;

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

        #region Brands
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
                    item.Descriptions.Load();
                    foreach (var description in item.Descriptions)
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
        #endregion


        #region Content
        public ActionResult UpdateContent(string id)
        {
            using (ContentStorage context = new ContentStorage())
            {
                string cultureName = LocaleHelper.GetCultureName();
                Content content = context.Content.Where(c => c.Language == cultureName)
                        .Where(c => c.Name == id)
                        .FirstOrDefault();
                if (content == null)
                {
                    ViewData["isNew"] = true;
                }
                else
                {
                    ViewData["id"] = id;
                    ViewData["text"] = content.Text;
                    ViewData["description"] = content.Description;
                    ViewData["keywords"] = content.Keywords;
                    ViewData["title"] = content.Title;
                    ViewData["isNew"] = false;
                }
            }
            return View(); 
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateContent(string id, string text, string description, string keywords, string title ,bool isNew)
        {
            using (ContentStorage context = new ContentStorage())
            {
                string cultureName = LocaleHelper.GetCultureName();
                Content content = null;
                if (isNew)
                {
                    content = new Content();
                    context.AddToContent(content);
                    content.Name = id;
                    content.Language = cultureName;
                }
                else
                {
                    content = context.Content
                        .Where(c => c.Language == cultureName)
                        .Where(c => c.Name == id)
                        .First();
                }
                content.Text = HttpUtility.HtmlDecode(text);
                content.Description = description;
                content.Keywords = keywords;
                content.Title = title;
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Content", new { id = id });
        }
        #endregion

        private void DeleteImage(string name)
        {
            string imagePath = Server.MapPath("~/Content/AdImages/" + name);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        #region CarAds
        private void PrepareViewData(long? id, CarAd carAd)
        {
            ViewData["id"] = id;

            List<SelectListItem> classes = new List<SelectListItem>
            {
                new SelectListItem{ Text = "��������", Value="1"},
                new SelectListItem{ Text = "�������", Value="2"},
                new SelectListItem{ Text = "������", Value="3"},
                new SelectListItem{ Text = "��������", Value="4"},
                new SelectListItem{ Text = "����������", Value="5"},
            };


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
                    ViewData["model"] = carAd.Model;
                    brands.ForEach(br => br.Selected = (int.Parse(br.Value) == carAd.Brand.Id));
                    classes.ForEach(cl => cl.Selected = (long.Parse(cl.Value) == carAd.Class));
                    Dictionary<string, string> descriptions = carAd.Descriptions.ToDictionary(cad => cad.Language, cad => cad.Text);
                    Dictionary<string, string> shorts = carAd.Descriptions.ToDictionary(cad => cad.Language, cad => cad.ShortDescription);
                  
                    ViewData["descriptionRu"] = descriptions["ru-RU"];
                    ViewData["descriptionEn"] = descriptions["en-US"];

                    ViewData["shortRu"] = shorts["ru-RU"];
                    ViewData["shortEn"] = shorts["en-US"];

                    ViewData["year"] = carAd.Year;
                }

                ViewData["brandId"] = brands;
                ViewData["classId"] = classes;
            }
        }

        public ActionResult AddEditCarAd(long? id)
        {

            CarAd carAd = new CarAd();

            using (CarAdStorage context = new CarAdStorage())
            {
                if (id.HasValue)
                {
                    carAd = context.CarAds.Include("Brand").Include("Descriptions").Include("Images").Where(ca => ca.Id == id.Value).First();
                }
            }

            PrepareViewData(id, carAd);

            return View(carAd);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddEditCarAd(
            long? id,
            long classId,
            long brandId,
            string model,
            string descriptionRu,
            string descriptionEn,
            string shortRu,
            string shortEn,
            int year
            )
        {
            using (CarAdStorage context = new CarAdStorage())
            {
                CarAd carAd;
                if (id.HasValue)
                {
                    carAd = context.CarAds.Include("Descriptions").Where(ca => ca.Id == id.Value).First();
                }
                else
                {
                    carAd = new CarAd();
                    context.AddToCarAds(carAd);
                }

                carAd.Model = model;
                CarAdDescription descriptionEnItem;
                CarAdDescription descriptionRuItem;
                if (carAd.Descriptions.Count > 0)
                {
                    descriptionEnItem = carAd.Descriptions.Where(d => d.Language == "en-US").First();
                    descriptionRuItem = carAd.Descriptions.Where(d => d.Language == "ru-RU").First();
                }
                else
                {
                    descriptionRuItem = new CarAdDescription();
                    descriptionRuItem.Language = "ru-RU";
                    carAd.Descriptions.Add(descriptionRuItem);
                    descriptionEnItem = new CarAdDescription();
                    descriptionEnItem.Language = "en-US";
                    carAd.Descriptions.Add(descriptionEnItem);
                }

                descriptionEnItem.Text = HttpUtility.HtmlDecode(descriptionEn);
                descriptionRuItem.Text = HttpUtility.HtmlDecode(descriptionRu);
                descriptionEnItem.ShortDescription = shortEn;
                descriptionRuItem.ShortDescription = shortRu;
                carAd.BrandReference.EntityKey = new EntityKey("CarAdStorage.Brands", "Id", brandId);
                carAd.Class = classId;
                carAd.Year = year;
                context.SaveChanges();
                return RedirectToAction("AddEditCarAd", new { id = carAd.Id });
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddCarAdImage(long carAdId, bool isDefault)
        {
            string file = Request.Files["image"].FileName;
            if (!string.IsNullOrEmpty(file))
            {
                string newFileName = IOHelper.GetUniqueFileName("~/Content/AdImages", file);
                string filePath = Path.Combine(Server.MapPath("~/Content/AdImages"), newFileName);
                Request.Files["image"].SaveAs(filePath);

                using (CarAdStorage context = new CarAdStorage())
                {
                    CarAdImage image = new CarAdImage();
                    image.CarAdReference.EntityKey = new EntityKey("CarAdStorage.CarAds", "Id", carAdId);
                    image.ImageSource = newFileName;
                    image.Default = isDefault;
                    context.AddToCarAdImages(image);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("AddEditCarAd", new { id = carAdId });
        }

        public ActionResult DeleteImage(long carAdId, long imageId)
        { 
            using(CarAdStorage context = new CarAdStorage())
            {
                CarAdImage image = context.CarAdImages.Where(i => i.Id == imageId).First();
                return RedirectToAction("AddEditCarAd", new { id = carAdId });
            }
        }

        public ActionResult SetDefaultImage(long adId, long defaultImage)
        {
            using (CarAdStorage context = new CarAdStorage())
            {
                var carAdImages = context.CarAdImages.Where(ca => ca.CarAd.Id == adId);
                foreach (var item in carAdImages)
                {
                    item.Default = item.Id == defaultImage;
                }
                context.SaveChanges();
            }
            return RedirectToAction("AddEditCarAd", new { id = adId });
        }
        #endregion
    }
}
