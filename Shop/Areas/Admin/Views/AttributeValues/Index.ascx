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
            <td class="adminLink">
                <%= Html.ActionLink("Изменть", "AddEdit", new { controller = "AttributeValues", valueId = item.Id, attributeId = ViewData["attributeId"] }, new { @class = "fancyAttributeValue" })%> |
                <%= Html.ActionLink("Удалить", "Delete", new { controller = "AttributeValues", id = item.Id }, new { onclick="return confirm('Вы уверены?')"})%>
            </td>
        </tr>
    
    <% } %>
    </table>

    <p>
        <%= Html.ActionLink("Добавить значение", "AddEdit", new { controller = "AttributeValues", attributeId = ViewData["attributeId"] }, new { @class = "fancyAttributeValue adminLink" })%>
    </p>