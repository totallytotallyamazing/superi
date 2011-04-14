<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<dynamic>>" %>

<p class="txtLeftMenu">Бренды:</p>

<%foreach (var item in Model)
  {
      string actionLink = Ajax.ActionLink((string)item.Name, "Index", 
          new { controller = "Brands", brandId = item.Id, groupId = ViewData["groupId"] },
          new AjaxOptions { OnSuccess = "BrandCatalogue.updateDockContent" },
          new { @class = "txtSubMenuItem", brandId = item.Id, groupId = ViewData["groupId"] }).ToString();
      %>
    <div class="menu">
        <p class="txtSubMenuItem">
            <%= actionLink %>
        </p>
    </div>
 <%} %>
