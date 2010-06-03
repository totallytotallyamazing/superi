<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Lady.Models.Product>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<% 
    string productClickLink = Html.ActionLink("[IMAGE]", "Show", new { id=Model.Id }).ToString();
    if (Roles.IsUserInRole("Administrators"))
    {
        productClickLink = Html.ActionLink("[IMAGE]", "AddEdit", "Products", new { area = "Admin", id = Model.Id, cId = ViewData["categoryId"], bId = ViewData["brandId"] }).ToString();
    }
%>

<div id="contentItemBox">
    <div id="contentItemBoxHeader">
        <p><a href="#">&trade; <%= Model.Brand.Name %></a></p>
    </div>
    <div id="contentItemBoxBg">
        <div id="contentItemFoto1">
            <%= productClickLink
                .Replace("[IMAGE]", 
                Html.CachedImage("~/Content/ProductImages", Model.ProductImages.Where(pi => pi.Default).First().ImageSource, "thumbnail2", Model.Name))%>
        </div>
        <div id="contentItemText1">
            <p><%= Model.Name %></p>
            <h2>Цвет: <strong>Синий</strong></h2>
            <% Html.RenderPartial("ProductAttributes", Model.ProductAttributeValues); %>
            <h3><%= Model.Price.ToString("#.##") %> <%= Dev.Helpers.WebSession.Currency %></h3>
        </div>
    </div>
    <div id="contentItemBoxFooter">
    </div>
</div>
