using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;
using Trips.Mvc.Helpers;

namespace Lady.Areas.Admin.Controllers
{
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
        public ActionResult AddEdit(Category category, int? Id, int? parentId)
        {
            using (ShopStorage context = new ShopStorage())
            {
                if (Id.HasValue && Id.Value > 0)
                {
                    category.Id = Id.Value;
                    object originalItem;
                    EntityKey entityKey = context.CreateEntityKey("ShopStorage.Categories", category.Id);
                    if (context.TryGetObjectByKey(entityKey, out originalItem))
                    {
                        context.ApplyPropertyChanges(entityKey.EntitySetName, category);
                    }
                }
                else
                {
                    context.AddToCategories(category);
                    if (parentId.HasValue)
                    {
                        EntityKey parentKey = new EntityKey("ShopStorage.Categories", "Id", parentId.Value);
                        category.ParentReference.EntityKey = parentKey;
                    }
                }
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Products", new { id = category.Id, area = "" });
        }

        [OutputCache(Duration=1, NoStore=true, VaryByParam="*")]
        public ActionResult Attributes(int id)
        {
            ViewData["id"] = id;
            using (ShopStorage context = new ShopStorage())
            {
                List<ProductAttribute> atrrtibutes = context.ProductAttributes.Include("Categories").ToList();
                int[] attributesSelected = atrrtibutes.Where(a => a.Categories.Where(c => c.Id == id).Count() > 0).Select(c=>c.Id).ToArray();
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
                PostData data = form.ProcessPostData("id");
                foreach (var item in data)
                {
                    int attributeId = int.Parse(item.Key);
                    bool contains = bool.Parse(item.Value["attribute"]);
                    if (contains)
                    {
                        Category category = context.Categories.Include("ProductAttributes").Where(c => c.Id == id).First();
                        if (category.ProductAttributes.Where(pa => pa.Id == attributeId).Count() == 0)
                        {
                            ProductAttribute attribute = new ProductAttribute();
                            attribute.EntityKey = new EntityKey("ShopStorage.ProductAttributes", "Id", attributeId);
                            attribute.Id = attributeId;
                            context.Attach(attribute);
                            category.ProductAttributes.Add(attribute);
                        }
                    }
                }

                context.SaveChanges();
            }
            Response.Write("<script type=\"text/javascript\">window.top.$.fancybox.close();</script>");
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
            return RedirectToAction("Index", "Categories", new { id = parentId, area = "Admin" });
        }
    }
}
