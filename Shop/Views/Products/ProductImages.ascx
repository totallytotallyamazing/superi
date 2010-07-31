<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductImage>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<% 
    var mainImage = Model.Where(m => m.Default).FirstOrDefault();
    var images = Model.Where(m => !m.Default).ToList();
%>
<div>
    <%if(mainImage!=null){ %>
    <%= Html.CachedImage("~/Content/ProductImages", mainImage.ImageSource, "mainView", mainImage.Product.Name) %>
    <%} %>
    <div class="orderButton">
        <a href="#" onclick="$(this).parents('form')[0].submit()" >Добавить в корзину</a>
    </div>
</div>
<div id="imagePreviews">
<%foreach (var item in images){%>
    <div class="imageItem">
        <%= Html.CachedImage("~/Content/ProductImages", item.ImageSource, "thumbnail1", mainImage.Product.Name) %>
    </div>
<%} %>
</div>
