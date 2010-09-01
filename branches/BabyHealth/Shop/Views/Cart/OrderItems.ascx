<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<table class="orderItems">
<% foreach (var item in WebSession.OrderItems){%>
    <tr>
        <td>
            <%= item.Value.Name %>
        </td>
        <td>
            <%= item.Value.Quantity %> шт.
        </td>
        <td>
            <%= Html.RenderPrice(item.Value.Price * item.Value.Quantity, WebSession.Currency, 0, ",") %>
        </td>
    </tr>           
<%} %>
</table>    