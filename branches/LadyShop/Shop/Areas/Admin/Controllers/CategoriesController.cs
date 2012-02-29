using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;
using Trips.Mvc.Helpers;
using System.Collections.ObjectModel;
using System.Data.Objects;
using Dev.Helpers;

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
        public ActionResult AddEdit(Category category, int? Id, int? parentId)
        {
            using (ShopStorage context = new ShopStorage())
            {
                if (Id.HasValue && Id.Value > 0)
                {
                    category.Id = Id.Value;
                    object originalItem;
                    EntityKey entityKey = new EntityKey("ShopStorage.Categories", "Id", category.Id);
                    if (context.TryGetObjectByKey(entityKey, out originalItem))
                    {
                        context.ApplyCurrentValues(entityKey.EntitySetName, category);
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

        [OutputCache(Duration = 1, NoStore = true, VaryByParam = "*")]
        public ActionResult Attributes(int id)
        {
            ViewData["id"] = id;
            using (ShopStorage context = new ShopStorage())
            {
                var atrrtibutes = context.ProductAttributes.Include("Categories").ToList();
                Category category = context.Categories.Include("Categories").Include("Parent").Where(c => c.Id == id).First();
                int[] attributesSelected = null;
                
                attributesSelected = atrrtibutes
                    .Where(a => a.Categories.Where(c => c.Id == id).Count() > 0)
                    .Select(c => c.Id).ToArray();

                attributesSelected = attributesSelected.Union(
                atrrtibutes
                    .Where(a => a.Categories.Intersect(category.Categories).Count() > 0)
                    .Select(c => c.Id)).ToArray();

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
                AddAttributesToCategory(context, category, addAttributeIds);
                RemoveAttributesFromCategory(context, category, removeAttributeIds);
                foreach (var item in category.Categories)
                {
                    AddAttributesToCategory(context, item, addAttributeIds);
                    RemoveAttributesFromCategory(context, item, removeAttributeIds);
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
                context.CleanupCategoryProducts(id);
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
