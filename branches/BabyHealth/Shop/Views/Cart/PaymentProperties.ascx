<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.PaymentProperty>>" %>
<table>
<% foreach (var item in Model){%>
    <tr>
        <td class="labelCell">
            <%= item.Name %>
        </td>
        <td>
            <%= Html.TextBox(item.FieldName) %>
        </td>
    </tr>  
<%} %>
</table>