using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;
using System.Collections.ObjectModel;
using System.Data.Objects;
using Dev.Helpers;
using System.IO;
using Dev.Mvc.Helpers;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class CategoriesController : Controller
    {
        //
        // GET: /Admin/Categories/

        public ActionResult AddEdit(int? id, int? parentId)
        {
            ViewData["title"] = "Создать категорию";
            ViewData["parentId"] = parentId;
            Category category = null;
            if (id.HasValue)
            {
                using (ShopStorage context = new ShopStorage())
                {
                    category = context.Categories.Where(c => c.Id == id.Value).First();
                    ViewData["title"] = "Редактировать " + category.Name;
                }
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult AddEdit(FormCollection form)
        {
            Category category = null;

            using (ShopStorage context = new ShopStorage())
            {
                int id = 0;
                if (int.TryParse(form["Id"], out id))
                {
                    category = context.Categories.First(c => c.Id == id);
                }
                else
                {
                    category = new Category();
                    context.AddToCategories(category);
                    int parentId = 0;
                    if (int.TryParse(form["parentId"], out parentId))
                    {
                        EntityKey parentKey = new EntityKey("ShopStorage.Categories", "Id", parentId);
                        category.ParentReference.EntityKey = parentKey;
                    }
                }

                TryUpdateModel(category,
                    new string[] { "Name", "SortOrder", "SeoKeywords", "SeoDescription", "Published" },
                    form.ToValueProvider());

                if (Request.Files["logo"] != null && !string.IsNullOrEmpty(Request.Files["Image"].FileName))
                {
                    if (!string.IsNullOrEmpty(category.Image))
                    {
                        IOHelper.DeleteFile("~/Content/CategoryImages", category.Image);
                    }
                    string fileName = IOHelper.GetUniqueFileName("~/Content/CategoryImages", Request.Files["Image"].FileName);
                    string filePath = Server.MapPath("~/Content/CategoryImages");
                    filePath = Path.Combine(filePath, fileName);
                    Request.Files["Image"].SaveAs(filePath);
                    category.Image = fileName;
                }

                context.SaveChanges();
            }

            return RedirectToAction("Index", "Products", new { id = category.Id, area = "" });
        }

        [OutputCache(Duration = 1, NoStore = true, VaryByParam = "*")]
        public ActionResult Attributes(int id)
        {
            ViewData["id"] = id;
            using (ShopStorage context = new ShopStorage())
            {
                var atrrtibutes = context.ProductAttributes.Include("Categories").ToList();
                Category category = context.Categories.Include("Categories").Include("Parent").Where(c => c.Id == id).First();
                int[] attributesSelected = null;
                if (category.Parent != null)
                {
                    attributesSelected = atrrtibutes
                        .Where(a => a.Categories.Where(c => c.Id == id).Count() > 0)
                        .Select(c => c.Id).ToArray();
                }
                else
                {
                    attributesSelected = atrrtibutes
                        .Where(a=> a.Categories.Intersect(category.Categories).Count()>0)
                        .Select(c => c.Id).ToArray();
                }

                ViewData["attributesSelected"] = attributesSelected;
                return View(atrrtibutes);
            }
        }

        [OutputCache(Duration = 1, NoStore = true, VaryByParam = "*")]
        [HttpPost]
        public void Attributes(int id, FormCollection form)
        {
            using (ShopStorage context = new ShopStorage())
            {
                PostData data = form.ProcessPostData(excludeFields: "id");
                Category category = context.Categories
                    .Include("Categories.ProductAttributes").Include("Parent").Include("ProductAttributes")
                    .Where(c => c.Id == id).First();
                Collection<int> addAttributeIds = new Collection<int>();
                Collection<int> removeAttributeIds = new Collection<int>();
                foreach (var item in data)
                {
                    int attributeId = int.Parse(item.Key);
                    bool contains = bool.Parse(item.Value["attribute"]);
                    if (contains)
                        addAttributeIds.Add(attributeId);
                    else
                        removeAttributeIds.Add(attributeId);
                }
                if (category.Parent != null)
                {
                    AddAttributesToCategory(context, category, addAttributeIds);
                    RemoveAttributesFromCategory(context, category, removeAttributeIds);
                }
                else
                {
                    foreach (var item in category.Categories)
                    {
                        AddAttributesToCategory(context, item, addAttributeIds);
                        RemoveAttributesFromCategory(context, item, removeAttributeIds);
                    }
                }
                context.SaveChanges();
            }
            Response.Write("<script type=\"text/javascript\">window.top.$.fancybox.close();</script>");
        }

        private ProductAttribute TryGetAttributeFromObjectStateManager(ShopStorage context, int attributeId)
        {
            EntityKey key = new EntityKey("ShopStorage.ProductAttributes", "Id", attributeId);
            ObjectStateEntry obj = null;
            ProductAttribute attribute = null;
            if (context.ObjectStateManager.TryGetObjectStateEntry(key, out obj))
            {
                attribute = (ProductAttribute)obj.Entity;
            }
            else
            {
                attribute = new ProductAttribute { EntityKey = key };
                attribute.Id = attributeId;
                context.Attach(attribute);
            }

            return attribute;
        }

        private void AddAttributesToCategory(ShopStorage context, Category category, Collection<int> attributeIds)
        {
            foreach (var attributeId in attributeIds)
            {
                if (category.ProductAttributes.Where(pa => pa.Id == attributeId).Count() == 0)
                {
                    ProductAttribute attribute = TryGetAttributeFromObjectStateManager(context, attributeId);
                    category.ProductAttributes.Add(attribute);
                }
            }
        }

        private void RemoveAttributesFromCategory(ShopStorage context, Category category, Collection<int> attributeIds)
        {
            foreach (var attributeId in attributeIds)
            {
                if (category.ProductAttributes.Where(pa => pa.Id == attributeId).Count() != 0)
                {
                    ProductAttribute attribute = TryGetAttributeFromObjectStateManager(context, attributeId);
                    category.ProductAttributes.Remove(attribute);
                }
            }   
        }

        public ActionResult Delete(int id)
        {
            int? parentId = null;

            using (ShopStorage context = new ShopStorage())
            {
                Category category = context.Categories.Include("Parent").Where(c => c.Id == id).First();
                if (category.Parent != null)
                {
                    parentId = category.Parent.Id;
                }
                context.DeleteObject(category);
                context.SaveChanges();
            }
            if (parentId.HasValue)
            {
                return RedirectToAction("Index", "Products", new { id = parentId, area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
    }
}
