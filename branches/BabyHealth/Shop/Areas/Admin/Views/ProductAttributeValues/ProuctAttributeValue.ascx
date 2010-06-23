<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeValue>>" %>
<% foreach (var item in Model)
   {%>
    <div>
     <%= Html.CheckBox("attr_" + item.Id) %>  <%= item.Value %>
     </div>
   <%} %>