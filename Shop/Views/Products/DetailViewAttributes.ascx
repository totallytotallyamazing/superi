<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeValue>>" %>

<%
    var pav = Model
    .GroupBy(m => m.ProductAttribute, m => m);    
%>

<% 
    foreach (var item in pav)
    {
        if (item.Key.Static)
        { %>
            <p>
                <%= item.Key.Name%>: <strong><%= item.First().Value%></strong>
            </p>  
        <%}
        else
        {
            Html.RenderPartial("ProductAttributesSelector", item);
        }
    }    
%>