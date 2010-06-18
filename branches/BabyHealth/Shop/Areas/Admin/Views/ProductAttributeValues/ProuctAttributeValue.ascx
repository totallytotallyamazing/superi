<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeValue>>" %>
<% foreach (var item in Model)
   {%>
     <%= Html.CheckBox("attr_" + item.Id) %>  <%= item.Value %>
   <%} %>