<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeValue>>" %>
<%
    var attributesSelected = (int[])ViewData["attributesSelected"]; 
    
    foreach (var item in Model)
    {%>
    <span>   
        <%= Html.RadioButton("static_" + item.ProductAttribute.Id, item.Id, attributesSelected.Contains(item.Id))%><%= item.Value %>
    </span>
   <%} %>