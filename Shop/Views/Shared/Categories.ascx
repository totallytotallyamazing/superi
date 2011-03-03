<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Shop.Models" %>
<% 
    using (ShopStorage context = new ShopStorage())
    {
         var categories = context.Categories.Include("Categories").Where(c => c.Parent == null);

        int? categoryId = null;
        if (ViewData["categoryId"] is int?)
            categoryId = (int?)ViewData["categoryId"];
        var a = ViewContext.RouteData.Values["controller"].ToString().ToLower();
        string action = ViewContext.RouteData.Values["action"].ToString().ToLower();
        bool isProductList = a == "products" && action == "index";
    
%>
<ul>
    <% foreach (var item in categories)
       {
           string content = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id, area="" }, null).ToString();
           if (categoryId == item.Id)
           {
               if (isProductList)
                   content = string.Format(@"<span class=""current"">{0} »</span>", item.Name);
               else
                   content = Html.ActionLink(item.Name + " »", "Index", "Products", new { id = item.Id }, new { @class = "current" }).ToString();
           }
    %>
    <li>
        <%= content %>
    </li>
    <% } %>
</ul>
<% if (Roles.IsUserInRole("Administrators"))
   { 
       
       %>
<p class="adminLink categoriesAdmin">
    <a href="/Admin/Categories/AddEdit">Добавить категорию</a>
</p>
<%}}%>
