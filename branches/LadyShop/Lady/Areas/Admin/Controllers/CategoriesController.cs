using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lady.Models;
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
        public ActionResult AddEdit(Category category, int? parentId)
        {
            using (ShopStorage context = new ShopStorage())
            {
                if (category.Id > 0)
                {
                    object originalItem;
                    EntityKey entityKey = context.CreateEntityKey("Categories", category.Id);
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
                        EntityKey parentKey = new EntityKey("ShopStorage.Cateories", "Id", parentId.Value);
                        category.ParentReference.EntityKey = parentKey;
                    }
                }
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Categories", new { id = parentId, area="Admin" });
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
