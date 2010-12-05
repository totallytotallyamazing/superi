<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.OrderItem>>" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<div id="basketBox" class="noMargin">
<% foreach (var item in Model)
   {%>
<div class="basketItem">
    <div class="basketItemText">
        <p><%= Html.ActionLink(item.Name, "Show", new { controller="Products", area="", id=item.Id})%></p>
    </div>
    <div class="basketItemField">
        <label>
            <%= Html.TextBox("oi_" + item.ProductId, item.Quantity, new { @class = "itemField" })%>
        </label>
    </div>
    <div class="od">
        <p>шт</p>
    </div>
    <div class="price" >
        <p id="price_<%= item.ProductId %>"><%= Html.RenderPrice(item.Price * item.Quantity, WebSession.Currency, 0, ",") %></p>
    </div>
    <div class="deleteItem">
        <p><%= Html.ActionLink("удалить :(", "Delete", new { id=item.ProductId })%></p>
    </div>
<%} %>
</div>
    <div id="itogi">
        <p>МОДНЫЕ ИТОГИ:</p>
    </div>
    <div id="itogiSummBox">
        <div id="itogiSumm">
            <p><%= Html.RenderPrice((float)ViewData["totalAmount"], WebSession.Currency, 0, ",") %></p>
        </div>
    </div>
</div>