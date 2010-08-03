<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductImage>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<div id="imagePreviews">
<%foreach (var item in Model){%>
    <div class="imageItem">
        <%= Html.CachedImage("~/Content/ProductImages", item.ImageSource, "thumbnail1", item.Product.Name) %>
    </div>
<%} %>
</div>