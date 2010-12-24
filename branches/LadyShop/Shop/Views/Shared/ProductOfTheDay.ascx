<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Shop.Models" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<% 
    using(ShopStorage context =  new ShopStorage()){
        var itemsList = context.Products.Include("Brand").Include("ProductImages").Include("ProductAttributeValues").Where(p => p.IsSpecialOffer).Select(p => p).ToList();
        
        Random rnd= new Random();
        var product = itemsList.OrderBy(i => rnd.Next()).First();
        product.ProductAttributeValues.ToList().ForEach(pav => pav.ProductAttributeReference.Load());

        string productClickLink = Html.ActionLink("[IMAGE]", "Show", new { controller="Products", id = product.Id }).ToString();
%>
<div class="productOfTheDay contentItemBox">
    <div class="contentItemBoxHeader">
        <p><a href="#">&trade; <%= product.Brand.Name%></a></p>
    </div>
    <div class="contentItemBoxBg">
        <div class="contentItemPhoto">
            <% if (product.ProductImages.Count > 0)
               { %>
            <%= productClickLink
                .Replace("[IMAGE]",
                Html.CachedImage("~/Content/ProductImages", product.ProductImages.Where(pi => pi.Default).First().ImageSource, "thumbnail2", product.Name))%>
            <%}
               else {
                   Response.Write(productClickLink.Replace("[IMAGE]", "редактировать"));
               }
                %>
                
        </div>
        <div class="contentItemText">
            <p><%= productClickLink.Replace("[IMAGE]", product.Name)%></p>
            <%if (!string.IsNullOrWhiteSpace(product.Color))
              { %>
            <div>Цвет: <strong><%= product.Color%></strong></div>
            <%} %>
            <% Html.RenderPartial("ProductAttributes", product.ProductAttributeValues); %>
            <h3><% Html.RenderPartial("Price", product); %></h3>
        </div>
    </div>
    <div class="contentItemBoxFooter">
    </div>
</div>
<%} %>