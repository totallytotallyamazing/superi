<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Shop.Models" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<% 
    using (ShopStorage context = new ShopStorage() )
    {
        Product product  = null;
        ProductImage img = null;
        List<Product> products = context.Products.Include("ProductImages").Where(p => p.Published).Where(p => p.IsSpecialOffer).ToList();
        if(products.Count>0)
        {
            Random rnd = new Random();
            int index = rnd.Next(products.Count - 1);
            product = products.Skip(index).Take(1).First();
            img = product.ProductImages.Where(m => m.Default).DefaultIfEmpty(new Shop.Models.ProductImage()).First();
        }   

        if(product!=null){
%>

<div id="mamaRecomends">
    <div id="recomendsContent">
        <div class="picture">
            <%= Html.CachedImage("~/Content/ProductImages", img.ImageSource, "thumbnail2", product.Name) %>
        </div>
        <div class="text">
            <div class="title">
                <%= Html.ActionLink(product.Name, "Show", new { controller = "Products", area="", id = product.Id })%>
            </div>
            <div class="description">
                <%= product.ShortDescription %>
            </div>
        </div>
        <div class="footer"></div>
    </div>
</div>

<%    }}
%>
