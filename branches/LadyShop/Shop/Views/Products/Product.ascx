<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<% 
    string productClickLink = Html.ActionLink("[IMAGE]", "Show", new { id=Model.Id }).ToString();
%>

<div id="contentItemBox">
    <div id="contentItemBoxHeader">
        <p><a href="#">&trade; <%= Model.Brand.Name %></a></p>
    </div>
    <div id="contentItemBoxBg">
        <div class="contentItemPhoto">
            <% if (Model.ProductImages.Count > 0)
               { %>
            <%= productClickLink
                .Replace("[IMAGE]",
                Html.CachedImage("~/Content/ProductImages", Model.ProductImages.Where(pi => pi.Default).First().ImageSource, "thumbnail2", Model.Name))%>
            <%}
               else {
                   Response.Write(productClickLink.Replace("[IMAGE]", "редактировать"));
               }
                %>
                
        </div>
        <div class="contentItemText">
            <p><%= Model.Name %></p>
            <% Html.RenderPartial("ProductAttributes", Model.ProductAttributeValues); %>
            <% if (!string.IsNullOrEmpty(Model.Color)){ %>
            <h2>Цвет: <strong><%= Model.Color %></strong></h2>
            <%} %>
            <h3><%= Html.RenderPrice(Model.Price, WebSession.Currency, 0, ",") %></h3>
        </div>
    </div>
    <div id="contentItemBoxFooter">
    </div>
</div>
