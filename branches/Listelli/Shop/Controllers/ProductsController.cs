using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Helpers;
using Shop.Models;
using Dev.Helpers;
using System.Web.Security;
using Dev.Mvc.Runtime;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Shop.Helpers.Validation;
using System.Net.Mail;
using Shop.Resources;
using Superi.Web.Mvc.Localization;
using System.Data.Objects;
using System.Globalization;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {

        public ActionResult Index(int id, int? brandId, int? page, string orderBy)
        {
            ViewData["categoryId"] = id;
            ViewData["brandId"] = brandId;
            ViewData["showAdminLinks"] = true;
            ViewData["isAdmin"] = Roles.IsUserInRole("Administrators");
            ViewData["page"] = page ?? 0;
            ViewData["orderBy"] = orderBy;
            ViewData["action"] = "Index";
            ViewData["showPager"] = true;
            ViewData["showSorting"] = true;
            WebSession.CurrentCategory = id;

            IQueryable<Product> products = null;
            using (ShopStorage context = new ShopStorage())
            {
                Category category = context.Categories.Include("Parent")
            .First(c => c.Id == id);

                ViewData["isContest"] = category.IsContest;

                products = context.Products
                       .Include("Brand")
                       .Include("ProductAttributeValues.ProductAttribute")
                       .Include("ProductAttributeStaticValues.ProductAttribute")
                       .Include("ProductImages")
                       .Include("Categories")
                       .Where(p => (!brandId.HasValue || p.Brand.Id == brandId.Value));
                if (category.Parent == null)
                {
                    ViewData["showAdminLinks"] = false;

                    products = products.Where(p => p.Categories.Any(
                        c => c.Id == id || (c.Parent != null && c.Parent.Id == id)))
                        .Where(p => p.ShowInRoot);
                }
                else
                    products = products.Where(p => (!brandId.HasValue || p.Brand.Id == brandId.Value))
                        .Where(p => p.Categories.Any(c => c.Id == id));
                category.UpdateValues(category.Localizations(context.ShopLocalResources).Where(l => l.Language == CultureInfo.CurrentUICulture.Name));
                orderBy = orderBy ?? string.Empty;
                products = ApplyOrdering(products, orderBy.ToLowerInvariant());

                if (!Roles.IsUserInRole("Administrators"))
                    products = products.Where(p => p.Published);

                ViewData["title"] = category.Name;

                ViewData["totalCount"] = products.Count();
                products = ApplyPaging(products, page);

                products = products.ToList().AsQueryable();


                var productAttributes = products.SelectMany(p => p.ProductAttributeStaticValues.Select(pasv => pasv.ProductAttribute)).Distinct();
                var localizaions = productAttributes.GetLocalizations(context.ShopLocalResources).ToList();

                foreach (var product in products)
                {
                    var pas = product.ProductAttributeStaticValues.AsQueryable().Select(pasv => pasv.ProductAttribute);
                    pas.ToList().ForEach(pa => pa.UpdateValues(localizaions));
                }

            }
            return View(products);
        }

        IQueryable<Product> ApplyOrdering(IQueryable<Product> products, string orderBy)
        {
            switch (orderBy)
            {
                case "name":
                    return products.OrderBy(p => p.Name);
                case "brand":
                    return products.OrderBy(p => p.Brand.Name);
                case "onlynew":
                    return products.OrderBy(p => p.SortOrder).Where(p => p.IsNew);
                case "tintlight":
                    return products.OrderBy(p => p.Color).Where(p => p.Color == "Светлый");
                case "tintdark":
                    return products.OrderBy(p => p.Color).Where(p => p.Color == "Темный");
                default:
                    return products.OrderBy(p => p.SortOrder);
            }
        }

        IQueryable<Product> ApplyPaging(IQueryable<Product> products, int? page)
        {
            int currentPage = page ?? 0;
            SiteSettings settings = Configurator.LoadSettings();
            int pageSize = settings.PageSize;
            if (page < 0)
                return products;
            return products.Skip(currentPage * pageSize).Take(pageSize);
        }



        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public ActionResult ShowContest(int id)
        {
            HttpContext.Items["IsProductView"] = true;
            using (ShopStorage context = new ShopStorage())
            {
                Product product = context.Products
                    .Include("ProductImages")
                    .Include("ProductAttributeValues")
                    .Include("ProductAttributeValues.ProductAttribute")
                    .Include("ProductAttributeStaticValues.ProductAttribute")
                    .Include("Tags.Products.ProductImages")
                    .Include("Tags.Products.ProductAttributeStaticValues.ProductAttribute")
                    .Include("Tags.Products.Categories")
                    .Include("Categories")
                    .Include("Tags.Products.Brand")
                    .Include("Brand").First(p => p.Id == id);
                ViewData["keywords"] = product.SeoKeywords;
                ViewData["description"] = product.SeoDescription;

                ViewData["quickQuestion"] = new QuickQuestionModel { ProductName = product.PartNumber + " " + product.Categories.First().Name + " " + product.Name };

                return View("ShowModalContest", product);
            }
        }

        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public ActionResult Show(int id)
        {
            HttpContext.Items["IsProductView"] = true;
            using (ShopStorage context = new ShopStorage())
            {
                Product product = context.Products
                    .Include("ProductImages")
                    .Include("ProductAttributeValues")
                    .Include("ProductAttributeValues.ProductAttribute")
                    .Include("ProductAttributeStaticValues.ProductAttribute")
                    .Include("Tags.Products.ProductImages")
                    .Include("Tags.Products.ProductAttributeStaticValues.ProductAttribute")
                    .Include("Tags.Products.Categories")
                    .Include("Categories")
                    .Include("Tags.Products.Brand")
                    .Include("Brand").First(p => p.Id == id);

                ViewData["keywords"] = product.SeoKeywords;
                ViewData["description"] = product.SeoDescription;
                ViewData["quickQuestion"] = new QuickQuestionModel { ProductName = product.PartNumber + " " + product.Categories.First().Name + " " + product.Name };

                var productAttributes = product.ProductAttributeStaticValues.Select(pasv => pasv.ProductAttribute).AsQueryable();
                var localizaions = productAttributes.GetLocalizations(context.ShopLocalResources);
                productAttributes.ToList().ForEach(pa => pa.UpdateValues(localizaions));

                return View("Show1", product);
            }
        }

        public ActionResult Tags(int id)
        {
            WebSession.CurrentTag = id;

            ViewData["tags"] = true;
            ViewData["showAdminLinks"] = false;
            using (ShopStorage context = new ShopStorage())
            {
                var products = context.Products
                    .Include("Brand")
                    .Include("ProductImages")
                    .Include("ProductAttributeValues.ProductAttribute")
                    .Where(p => p.Tags.Where(t => t.Id == id).Count() > 0)
                    .OrderBy(p => p.SortOrder)
                    .ToList();
                return View("Index", products);
            }
        }

        public ActionResult Search(string searchField)
        {
            ViewData["tags"] = true;
            WebSession.CurrentTag = int.MinValue;
            WebSession.CurrentCategory = int.MinValue;

            ViewData["title"] = "Результаты поиска";

            string processedString = string.Join(" or ",
                        searchField.Split(' ').Where(a => !a.Equals("or", StringComparison.OrdinalIgnoreCase)).ToArray());

            List<Product> products = null;

            if (!string.IsNullOrWhiteSpace(processedString))
            {
                using (ShopStorage context = new ShopStorage())
                {
                    try
                    {
                        int[] ids = context.GetSearchResults(processedString);
                        products = context.Products
                            .Include("ProductAttributeValues")
                            .Include("Categories")
                            .Include("ProductImages")
                            .Include("ProductAttributeStaticValues.ProductAttribute")
                            .Include("Brand")
                            .Where(ContextExtension.BuildContainsExpression<Product, int>(p => p.Id, ids))
                            .OrderBy(p => p.SortOrder)
                            .ToList();
                    }
                    catch
                    {

                    }
                }
            }
            return View("Index", products);
        }

        public ActionResult Favorites()
        {
            ViewData["title"] = "Отмеченные позиции";
            List<Product> products = null;

            if (HttpContext.Request.Cookies["favorites"] != null)
            {

                using (ShopStorage context = new ShopStorage())
                {
                    try
                    {

                        products = context.Products
                            .Include("Brand")
                            .Include("ProductAttributeValues")
                            .Include("Categories")
                            .Include("ProductImages")
                            .Include("ProductAttributeStaticValues.ProductAttribute")
                            .Where(ContextExtension.BuildContainsExpression<Product, int>(p => p.Id, Models.Favorites.FavoritesProductIds))
                            .OrderBy(p => p.SortOrder)
                            .ToList();
                    }
                    catch
                    {

                    }
                }
            }
            return View("Index", products);
        }




        [HttpPost]
        public void QuickQuestion(QuickQuestionModel model)
        {
            SiteSettings settings = Configurator.LoadSettings();
            MailHelper.SendTemplate(new List<MailAddress> { new MailAddress(settings.ReceiverMail) },
                "Форма обратной связи", "QuestionTemplate.htm",
                null, true, model.Name, model.Email, model.Text, model.ProductName);
        }
    }
}

namespace Shop.Models
{
    public class QuickQuestionModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Global))]
        [LocalizedDisplayName("NameLastName", NameResourceType = typeof(Global))]
        public string Name { get; set; }
        [LocalizedDisplayName("Email", NameResourceType = typeof(Global))]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(Global))]
        public string Email { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Global))]
        [LocalizedDisplayName("QueryText", NameResourceType = typeof(Global))]
        public string Text { get; set; }
        public string ProductName { get; set; }
        [Captcha("ValidateCaptcha", "Captcha", "value", ErrorMessageResourceName = "InvalidCaptcha", ErrorMessageResourceType = typeof(Global))]
        [Required(ErrorMessageResourceName = "RequiredCaptcha", ErrorMessageResourceType = typeof(Global))]
        [DisplayName("")]
        public string Captcha { get; set; }
    }
}