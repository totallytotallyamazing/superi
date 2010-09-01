<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Category>>" %>
<%@ Import Namespace="Dev.Helpers" %>
<ul class="treeview" id="productGroups">
<% 
    foreach (var item in Model)
    {
        string extraClass = "";
        string actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, null).ToString();
        if (item.Id == WebSession.CurrentCategory)
        {
            actionLink = string.Format("<span>{0}</span>", item.Name);
            extraClass = " current";
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