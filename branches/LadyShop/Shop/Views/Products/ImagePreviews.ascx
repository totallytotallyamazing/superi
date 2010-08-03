<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductImage>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<div id="imagePreviews">
<%foreach (var item in images){%>
    <div class="imageItem">
        <%= Html.CachedImage("~/Content/ProductImages", item.ImageSource, "thumbnail1", mainImage.Product.Name) %>
    </div>
<%} %>
</div>