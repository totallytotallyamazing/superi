<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeValue>>" %>
<%
    var attributesSelected = (int[])ViewData["attributesSelected"]; 
    foreach (var item in Model)
    {%>
    <div>
     <%= Html.CheckBox("attr_" + item.Id, attributesSelected.Contains(item.Id))%>  <%= item.Value %>
     </div>
   <%} %>