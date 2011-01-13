<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<% 
    string productClickLink = Html.ActionLink("[IMAGE]", "Show", new { id=Model.Id }).ToString();

    string className = Model.OldPrice.HasValue ? (Model.IsSpecialOffer ? "contentItemBox dayDiscount" : "contentItemBox lowPrice") : "contentItemBox";
    //if (Roles.IsUserInRole("Administrators"))
    //{
    //    productClickLink = Html.ActionLink("[IMAGE]", "AddEdit", "Products", new { area = "Admin", id = Model.Id, cId = ViewData["categoryId"], bId = ViewData["brandId"] }, null).ToString();
    //}
%>

<div class="<%= className %>">
    <div class="contentItemBoxHeader">
        <p><a href="#">&trade; <%= (Model.Brand != null) ? Model.Brand.Name : string.Empty%></a></p>
    </div>
    <div class="contentItemBoxBg">
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
            <p><%= productClickLink.Replace("[IMAGE]", Model.Name)%></p>
            <%if(!string.IsNullOrWhiteSpace(Model.Color)){ %>
            <div>Цвет: <strong><%= Model.Color %></strong></div>
            <%} %>
            <% Html.RenderPartial("ProductAttributes", Model.ProductAttributeValues); %>
            <h3><% Html.RenderPartial("Price", Model); %></h3>
        </div>
    </div>
    <div class="contentItemBoxFooter">
    </div>
</div>
