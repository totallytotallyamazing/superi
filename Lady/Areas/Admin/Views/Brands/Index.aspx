<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lady.Models.Brand>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Бренды
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="includes">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>
                Лого
            </th>
            <th>
                Название
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%= Html.Image("~/Content/BrandLogos/" + item.Logo, item.Name)%>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.ActionLink("Редактировать", "AddEdit", new { id = item.Id }, new { @class="fancy"})%> |
                <%= Html.ActionLink("Удалить", "Delete", new { id=item.Id }, new { onclick="return confirm('Вы уверены?')"})%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Добавить", "AddEdit", null, new { @class = "fancy" })%>
    </p>

</asp:Content>

