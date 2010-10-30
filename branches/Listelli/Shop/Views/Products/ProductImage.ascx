<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.ProductImage>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<% 
    var mainImage = Model;
    string alt = (mainImage != null) ? mainImage.Product.Name : "";
%>
<%if (mainImage != null){ %>
    <% Html.RenderAction("ShowMain", new { controller = "Graphics", area = "", id = mainImage.ImageSource, alt = mainImage.Product.Name }); %>
<%} %>