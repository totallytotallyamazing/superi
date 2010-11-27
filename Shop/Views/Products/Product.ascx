<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<% 
    string productClickLink = Html.ActionLink("[IMAGE]", "Show", new { id=Model.Id }).ToString();
    if (Roles.IsUserInRole("Administrators"))
    {
        productClickLink = Html.ActionLink("[IMAGE]", "AddEdit", "Products", new { area = "Admin", id = Model.Id, cId = ViewData["categoryId"], bId = ViewData["brandId"] }, null).ToString();
    }
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
            <h2>Цвет: <strong>Синий</strong></h2>
            <% Html.RenderPartial("ProductAttributes", Model.ProductAttributeValues); %>
            <h3><%= Model.Price.ToString("#.##") %> <%= Dev.Helpers.WebSession.Currency %></h3>
        </div>
    </div>
    <div id="contentItemBoxFooter">
    </div>
</div>
