<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Product>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<% if (Model.Count() > 0){ %>
<div id="skidkiSlot">
    <% foreach (var item in Model){%>
    <% Shop.Models.ProductImage img = item.ProductImages.Where(m => m.Default).DefaultIfEmpty(new Shop.Models.ProductImage { Product = new Shop.Models.Product { Name = item.Name } }).First();%>
    <div id="skidkiBoxSlot">
        <div id="imgBoxSlot"><%= Html.CachedImage("~/Content/ProductImages", img.ImageSource, "dayDiscount", item.Name)%></div>
        <p><%= Html.ActionLink(item.Name, "Show", new { area="", controller = "Products", id = item.Id }) %></p>
        <% Html.RenderPartial("ProductAttributes", item.ProductAttributeValues.Where(pav => pav.ProductAttribute.Id == 1)); %>
        <% if(!string.IsNullOrWhiteSpace(item.Color)){ %>
        <p>Цвет: <strong><%= item.Color %></strong></p>
        <%} %>
        <h4><%= Html.RenderPrice(item.Price, WebSession.Currency, 0, ",")%></h4>
    </div>
    <%} %>
</div>
<%} %>