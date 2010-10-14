<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Product>" %>

<% if(Model.ProductVariants.Count >0 ){ %>
    <% Html.RenderPartial("ProductVariantImage", Model.ProductVariants.OrderBy(pv=>pv.SortOrder).First().Image); %>
<%} else{ %>
    <% Html.RenderPartial("ProductImage", Model); %>
<%} %>