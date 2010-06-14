<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductImage>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<% 
    var mainImage = Model.Where(m => m.Default).First();
    var images = Model.Where(m => !m.Default).ToList();
%>

<%= Html.CachedImage("~/Content/ProductImages", mainImage.ImageSource, "mainView", mainImage.Product.Name) %>
<div id="new1">
</div>


