<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Category>>" %>
<%@ Import Namespace="Dev.Helpers" %>
<ul class="treeview" id="productGroups">
<% 
    foreach (var item in Model)
    {
        string extraClass = "";
        string actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, null).ToString();
        bool isProductView = ViewContext.RouteData.Values["action"].ToString().ToLower() == "show";
        if (item.Id == WebSession.CurrentCategory)
        {
            extraClass = " current";
            if (!isProductView)
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

<% if(Roles.IsUserInRole("Administrators")){ %>    
    <p class="adminLink categoriesAdmin">   
        <%= Html.ActionLink("Добавить категорию", "AddEdit", "Categories", new { area="admin", parentId=WebSession.CurrentCategory }, null)%>
    </p>
<%} %>