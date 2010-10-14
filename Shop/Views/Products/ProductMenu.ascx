<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>

<% if(Model.ProductVariants.Count >0 ){ %>
    <% Html.RenderPartial("ProductVariants", Model.ProductVariants); %>
<%} else{ %>
    <% Html.RenderPartial("ImagePreviews", Model.ProductImages.OrderByDescending(pi => pi.Default)); %>
<%} %>