<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductImage>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<%if(Model.Count()>1){ %>
<div id="imagePreviews">
<%foreach (var item in Model){%>
    <div class="imageItem">
        <%= Html.CachedImage("~/Content/ProductImages", item.ImageSource, "thumbnail1", item.Product.Name)%>
        <div class="fadeImage"></div>
    </div>
<%} %>
</div>
<%} %>
