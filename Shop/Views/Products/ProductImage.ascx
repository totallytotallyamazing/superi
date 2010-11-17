<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.ProductImage>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<% 
    var mainImage = Model;
    string alt = (mainImage != null) ? mainImage.Product.Name : "";
%>

<div id="SlotProductFoto">
    <%if(mainImage !=null){ %>
    <a id="mi" href="/Content/ProductImages/<%= mainImage.ImageSource %>">
        <%= Html.CachedImage("~/Content/ProductImages", Model.ImageSource, "mainView", alt) %>
    </a>
    <%} %>
    <div class="orderButton">
        <input value="Добавить в корзину" type="submit" />
    </div>
</div>

