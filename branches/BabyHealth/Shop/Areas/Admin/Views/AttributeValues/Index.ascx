<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductAttributeValue>>" %>

    <table>
        <tr>
            <th>
                Значение
            </th>
            <th>
                Порядок
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%= Html.Encode(item.Value) %>
            </td>
            <td>
                <%= Html.Encode(item.SortOrder) %>
            </td>
            <td>
                <%= Html.ActionLink("Изменть", "Edit", new { controller="AttributeValues", id=item.Id, attributeId=ViewData["attributeId"] }) %> |
                <%= Html.ActionLink("Удалить", "Delete", new { controller="AttributeValues", id=item.Id })%>
            </td>
        </tr>
    
    <% } %>
    </table>

    <p>
        <%= Html.ActionLink("Добавить значение", "AddEdit", new { controller = "AttributeValues", id = ViewData["attributeId"] }, new { @class="fancyAttributeValue iframe" })%>
    </p>


