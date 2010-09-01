<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeValue>>" %>

<% 
    var pav = Model.GroupBy(m => m.ProductAttribute, m=>m);
    foreach (var item in pav)
    {%>
        <%= item.Key.Name %>: <%= Html.DropDownList("attr_" + item.Key.Id, new SelectList(item, "Id", "Value")) %>
  <%}
%>