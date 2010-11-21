<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Category>>" %>
<%@ Import Namespace="Dev.Helpers" %>

<div id="subGroups">
<ul class="treeview" id="productGroups">
<% 
    string[] listPages = { "index", "search", "tags" };
    foreach (var item in Model)
    {
        string extraClass = "";
        string actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id, area = "" }, new { @class = "txtSubMenuItem" }).ToString();
        string currentAction = ViewContext.RouteData.Values["action"].ToString().ToLower();
        bool isProductList = listPages.Contains(currentAction);
        isProductList = isProductList & ViewContext.RouteData.Values["controller"].ToString().ToLower() == "products";
        if (item.Id == WebSession.CurrentCategory)
        {
            extraClass = " current";
            if (isProductList && ViewData["brandId"] == null)
            actionLink = string.Format("<span>{0}</span>", item.Name);
        }
        %>
    <li>
        <div class="subMenuItem<%= extraClass %>">
            <%= actionLink%>
        </div>
    </li>
  <%}        
%>
</ul>
</div>
<% if(Roles.IsUserInRole("Administrators")){ %>    
    <p class="adminLink categoriesAdmin">   
        <%= Html.ActionLink("Добавить подкатегорию", "AddEdit", "Categories", new { area="admin", parentId=WebSession.CurrentCategory }, null)%>
    </p>
<%} %>