<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>

<div>
    <%= Html.ResourceString("City") %><br />
    <%= Html.DropDownList("currentCity", (List<SelectListItem>)ViewData["citiesList"]) %>
</div>
<div>
    <%= Html.ResourceString("Category") %><br />
     <%= Html.DropDownList("currentCategory", (List<SelectListItem>)ViewData["categoriesList"]) %>
</div>

