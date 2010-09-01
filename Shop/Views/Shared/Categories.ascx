<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Category>>" %>
<%@ Import Namespace="Dev.Helpers" %>
<div id="menuBox">
    <div id="liHeader">
    </div>
    <div id="newsContent">
        <div id="classMenuItems">
        <% 
        foreach (var item in Model)
        {
            bool expandCategory = false;
            string actionLink = "";
            string extraClass = "";
            if (item.Id == WebSession.CurrentCategory)
            {
                actionLink = string.Format("<span>{0}</span>", item.Name);
                extraClass = " current";
                expandCategory = true;
            }
            else if (item.Categories.Select(c => c.Id).Contains(WebSession.CurrentCategory))
            {
                actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, null).ToString();
                extraClass = " current";
                expandCategory = true;
            }
            else
            {
                actionLink = Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, null).ToString();
            }
            %>
            <div class="classMenuItem<%= extraClass %>">
                <p>
                    <%= actionLink %>
                </p>
            </div>
      <%
          if (WebSession.CurrentCategory == item.Id || expandCategory)
              Html.RenderPartial("SubCategories", item.Categories.OrderBy(c=>c.SortOrder));
        }%>
        <% if(Roles.IsUserInRole("Administrators")){ %>    
        <p class="adminLink rootCategoriesAdmin">   
        <%= Html.ActionLink("Добавить категорию (корневую)", "AddEdit", "Categories", new { area="admin" }, null)%>
        </p>
        <%} %>
        </div>
    </div>
    <div id="newsFooter">
    </div>
</div>

