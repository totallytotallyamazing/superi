<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Shop.Models" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<% 
    using(ShopStorage context =  new ShopStorage()){
        var itemsList = context.Products.Include("ProductImages").Include("ProductAttributeValues").Where(p => p.IsSpecialOffer).Select(p => new
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Sizes = p.ProductAttributeValues.Where(pav => pav.ProductAttribute.Id == 1),
            Color = p.Color,
            ProductImages = p.ProductImages
        }).ToList();
        
        Random rnd= new Random();
        var items = itemsList.OrderBy(i => rnd.Next()).Take(3).ToList();

        items.ForEach(p => p.Sizes.ToList()
                    .ForEach(pav => pav.ProductAttributeReference.Load()));
%>

<% if(items.Count()>0){ %>
    <div id="skidki">
        <h2>СКИДКА ДНЯ</h2>
        <% foreach (var item in items){%>
        <div class="skidkiBox">
            <div class="imgBox"><%= Html.CachedImage("~/Content/ProductImages", (item.ProductImages.Where(pi => pi.Default).Count() > 0) ? item.ProductImages.First(pi => pi.Default).ImageSource : "", "dayDiscount", item.Name)%></div>
            <p><%= Html.ActionLink(item.Name, "Show", new { area="", controller = "Products", id = item.Id }) %></p>
            <% Html.RenderPartial("ProductAttributes", item.Sizes); %>
            <% if(!string.IsNullOrWhiteSpace(item.Color)){ %>
            <p>Цвет: <strong><%= item.Color %></strong></p>
            <%} %>
            <h4><%= Html.RenderPrice(item.Price, WebSession.Currency, 0, ",")%></h4>
        </div>
         <%} %>
    </div>
<%}} %>