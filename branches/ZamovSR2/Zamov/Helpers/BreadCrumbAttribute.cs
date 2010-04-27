using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zamov.Controllers;
using System.Web.Caching;
using Zamov.Models;

namespace Zamov.Helpers
{
    public class BreadCrumbAttribute : ActionFilterAttribute
    {

        public string Text { get; set; }
        public string Url { get; set; }
        public string ResourceName { get; set; }
        public int CategoryId { get; set; }
        public bool SubCategoryId { get; set; }
        public bool DealerId { get; set; }
        public int GroupId { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string url = string.Empty;
            string text = string.Empty;

            if (CategoryId != 0)
            {
                url = "/Categories";
                text = CategoryName(CategoryId);
            }
            else if (DealerId)
            {
                url = "/Dealers/SelectDealer/" + SystemSettings.SelectedDealer;
                text = DealerName(SystemSettings.SelectedDealer.Value);
            }
            else if (GroupId != 0)
            {
                ProcessGroup(GroupId, filterContext.HttpContext);
                return;
            }
            else if (!string.IsNullOrEmpty(ResourceName))
                text = ResourcesHelper.GetResourceString(ResourceName);
            if (string.IsNullOrEmpty(text))
                text = Text;
            if (string.IsNullOrEmpty(url))
                url = Url;
            BreadCrumbsExtensions.AddBreadCrumb(filterContext.HttpContext, text, url);
            base.OnActionExecuting(filterContext);
        }

        public static void ProcessCategory(int categoryId, HttpContextBase httpContext)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                var chain = context.GetCachedCategoryChain(categoryId, SystemSettings.CurrentLanguage);
                foreach (var item in chain)
                {
                    BreadCrumbsExtensions.AddBreadCrumb(httpContext, item.Name, "/Dealers/" + item.Id);
                }
            }
        }

        public static void ProcessGroup(int groupId, HttpContextBase httpContext)
        {
            SortedList<string, string> groups = new SortedList<string, string>();
            
            using(ZamovStorage context = new ZamovStorage())
            {
                Group item = (from g in context.Groups.Include("Parent").Include("Dealer") where g.Id == groupId select g).First();
                int dealerId = item.Dealer.Id;
                string dealerName = item.Dealer.Name;
                groups.Add("/Products/" + dealerName + "/" + item.Id, GroupName(item.Id));
                Group parent = item.Parent;
                while (parent != null)
                {
                    groups.Add("/Products/" + dealerName + "/" + parent.Id, GroupName(parent.Id));
                    parent.ParentReference.Load();
                    parent = parent.Parent;
                }
            }
            groups.Reverse();
            foreach (var item in groups)
                BreadCrumbsExtensions.AddBreadCrumb(httpContext, item.Value, item.Key);
        }

        private static string GroupName(int groupId)
        {
            string cacheKey = "groupName_" + groupId + SystemSettings.CurrentLanguage;
            if (HttpContext.Current.Cache[cacheKey] == null)
            {
                using (ZamovStorage context = new ZamovStorage())
                {
                    string groupName = (from g in context.Groups
                                        join name in context.Translations on g.Id equals name.ItemId
                                        where name.TranslationItemTypeId == (int)ItemTypes.Group
                                        && name.Language == SystemSettings.CurrentLanguage
                                        && g.Id == groupId
                                        select name.Text).First();
                    HttpContext.Current.Cache[cacheKey] = groupName;
                }
            }
            return HttpContext.Current.Cache[cacheKey].ToString();
        }

        private string CategoryName(int categoryId)
        {
            string cacheKey = "categoryName_" + categoryId + SystemSettings.CurrentLanguage;

            if (HttpContext.Current.Cache[cacheKey] == null)
            {
                using (ZamovStorage context = new ZamovStorage())
                {
                    string categoryName = (from category in context.Categories
                                           join name in context.Translations on category.Id equals name.ItemId
                                           where name.TranslationItemTypeId == (int)ItemTypes.Category
                                           && name.Language == SystemSettings.CurrentLanguage
                                           && category.Id == categoryId
                                           select name.Text).FirstOrDefault();
                    if (categoryName != null)
                        HttpContext.Current.Cache[cacheKey] = categoryName;
                }
            }
            return (string)HttpContext.Current.Cache[cacheKey];
        }

        public static string DealerName(int dealerId)
        {
            string cacheKey = "dealerName_" + dealerId + SystemSettings.CurrentLanguage;
            if (HttpContext.Current.Cache[cacheKey] == null)
            {
                using (ZamovStorage context = new ZamovStorage())
                {
                    string dealerName = (from dealer in context.Dealers
                                         join name in context.Translations on dealer.Id equals name.ItemId
                                         where name.TranslationItemTypeId == (int)ItemTypes.DealerName
                                         && name.Language == SystemSettings.CurrentLanguage
                                         && dealer.Id == dealerId
                                         select name.Text).First();
                    HttpContext.Current.Cache[cacheKey] = dealerName;
                }
            }
            return (string)HttpContext.Current.Cache[cacheKey];
        }
    }
}
