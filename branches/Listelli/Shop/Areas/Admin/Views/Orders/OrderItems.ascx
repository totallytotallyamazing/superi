<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.OrderItem>>" %>

    <table>
        <tr>
            <th></th>
            <th>
                Название
            </th>
            <th>
                Цена
            </th>
            <th>
                Количество
            </th>
            <th>
                Стоимость
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Посмотреть", "Show", new { controller="Products", area="", id=item.ProductId })%> |
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Price %>
            </td>
            <td>
                <%: item.Quantity %>
            </td>
            <td>
                <%: item.Price * item.Quantity %>
            </td>
        </tr>
    
    <% } %>

    </table>
