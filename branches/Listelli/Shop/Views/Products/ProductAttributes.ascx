<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeValue>>" %>

<% 
    var pav = Model.OrderBy(pa => pa.SortOrder).GroupBy(m => m.ProductAttribute.Name, m => m.Value);

    foreach (var item in pav)
    {%>
        Размер: <strong><%= string.Join(",", item.ToArray()) %></strong>
  <%}
%>

