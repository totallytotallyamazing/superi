<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeStaticValue>>" %>
<%@ Import Namespace="Shop.Models" %>
<%@ Import Namespace="Superi.Web.Mvc.Localization" %>

<% 
    var context = ViewData["context"] as ShopStorage;
%>

<% foreach (var item in Model.OrderBy(pa=>pa.ProductAttribute.SortOrder)){%>
    <p><span class="attributeLabel"><%= item.ProductAttribute.Name %>:</span>
    <span class="attributeValue"><%= item.Value %></span></p>
<%} %>