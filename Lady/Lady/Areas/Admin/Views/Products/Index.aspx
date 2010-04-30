<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lady.Models.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>
                Артикул
            </th>
            <th>
                Наименование
            </th>
            <th>
                Цена
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.PartNumber) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.Price) %>
            </td>
            <td>
                <%= Html.ActionLink("Изменить", "AddEdit", new { id=item.Id }) %> |
                <%= Html.ActionLink("Удалить", "Delete", new { id=item.Id })%>
            </td>

        </tr>
    
    <% } %>
    </table>
    
    <p>
        <%= Html.ActionLink("Создать", "AddEdit")%>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

