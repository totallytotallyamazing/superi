<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Superi.Web.Mvc.Localization" %>
<%@ Import Namespace="Shop.Models" %>
<% 
    IQueryable<Category> categories;
    using (var context = new ShopStorage())
    {
        //context.Categories.MergeOption = System.Data.Objects.MergeOption.NoTracking;
        categories = context.Categories.Include("Categories")
            .Where(c => c.Parent == null)
            .Where(c => c.Published)
            // .Localize((c, l) => new { Category = c, Localizations = l}, context.ShopLocalResources, null).ToList()
            // .Select(c=>c.Category.UpdateValues(c.Localizations))
            .OrderBy(c => c.SortOrder).ToList().AsQueryable();
        var localizaions = categories.GetLocalizations(context.ShopLocalResources).ToList();
        categories.ToList().ForEach(c => c.UpdateValues(localizaions));
%>

<%
        string currentUrl = Request.Url.ToString().ToLower();
        if (!currentUrl.Contains("konkurs") && !currentUrl.Contains("conditions") && !currentUrl.Contains("fond"))
        {
%>

<div id="leftMenu">
<% string[] listPages = {"index", "search", "tags"};
   foreach (var item in categories)
   {
       bool expandCategory = false;
       string actionLink = "";
       bool isProductList = listPages.Contains(ViewContext.RouteData.Values["action"].ToString().ToLower());
       isProductList = isProductList & ViewContext.RouteData.Values["controller"].ToString().ToLower() == "products";
       if (item.Id == WebSession.CurrentCategory)
       {
           if (isProductList && ViewData["brandId"] == null)
           {
               actionLink = string.Format("<span>{0}</span>", item.Name);
           }
           else
           {
               actionLink =
                   Html.ActionLink(item.Name, "Index", "Products", new {id = item.Id, area = ""},
                                   new {@class = "currentMain"}).ToString();
           }
           expandCategory = true;
       }
       else if (item.Categories.Select(c => c.Id).Contains(WebSession.CurrentCategory))
       {
           actionLink =
               Html.ActionLink(item.Name, "Index", "Products", new {id = item.Id, area = ""},
                               new {@class = "currentMain"}).ToString();
           expandCategory = true;
       }
       else
       {
           actionLink =
               Html.ActionLink(item.Name, "Index", "Products", new {id = item.Id, area = ""},
                               new {@class = "txtLeftMenu"}).ToString();
       }
%>
    <div class="leftMenuElement">
    
        <%= actionLink %>


    </div>
    <% if (WebSession.CurrentCategory == item.Id || expandCategory)
       {
           var subLocalizations = item.Categories.AsQueryable().GetLocalizations(context.ShopLocalResources);
           Html.RenderPartial("SubCategories", item.Categories.OrderBy(c => c.SortOrder).Select(c=>c.UpdateValues(subLocalizations)));
       }
   } %>

<% if (Roles.IsUserInRole("Administrators"))
   { %>    
    <p class="adminLink rootCategoriesAdmin">   
    <%= Html.ActionLink("Добавить категорию", "AddEdit", "Categories", new {area = "admin"}, null) %>
    </p>
<% } %>
</div>
<% }
    } %>