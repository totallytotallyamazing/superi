<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.ProductImage>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<div id="SlotProductFoto">
    <%if(Model!=null){ %>
    <%= Html.CachedImage("~/Content/ProductImages", Model.ImageSource, "mainView", Model.Product.Name) %>
    <%} %>
    <div class="orderButton">
        <input value="Добавить в корзину" type="submit" />
    </div>
</div>

