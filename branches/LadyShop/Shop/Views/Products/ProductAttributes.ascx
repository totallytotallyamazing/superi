<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeValue>>" %>

<% 
    var pav = Model
        .Where(m => m.ProductAttribute.ShowInCommonView)
        .OrderBy(m => m.SortOrder)
        .GroupBy(m => m.ProductAttribute, m => m.Value);

    foreach (var item in pav)
    {%>
        <div>
            <%= item.Key.ListName %>: <strong><%= string.Join(", ", item.ToArray()) %></strong>
        </div>
  <%}
%>

