<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeStaticValue>>" %>

<% foreach (var item in Model.Where(pa => pa.ProductAttribute.SortOrder < 100).OrderBy(pa => pa.ProductAttribute.SortOrder))
   {%>
    <p><span class="attributeLabel"><%= item.ProductAttribute.Name %>:</span>
    <span class="attributeValue"><%= item.Value %></span></p>
<%} %>