<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Lady.Models.ProductAttributeValue>>" %>

<% 
    var pav = Model.GroupBy(m => m.ProductAttribute.Name, m => m.Value);

    foreach (var item in pav)
    {%>
        <h2>Размер: <strong><%= string.Join(",", item.ToArray()) %></strong></h2>
  <%}
%>

