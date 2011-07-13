<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Subscriber>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Список email-адресов для рассылки новостей
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Список email-адресов для рассылки новостей</h2>
    <br />
    <table>
        <tr>
            <th>
                Email
            </th>
            <th>
                Активный
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%: item.Email %>
            </td>
            <td align="center">
                <%: item.IsActive?"Да":"Нет" %>
            </td>
            <td>
                <%: Html.ActionLink("Редатировать", "Edit", new { id = item.Email }, new {@class="adminLink" })%> |
                <%: Html.ActionLink("Удалить", "Delete", new { id=item.Email },new {@class="adminLink", onclick = "return confirm('Удалить запись?')" })%>
            </td>
        </tr>
    <% } %>

    </table>
    <br />
    <p>
        <%: Html.ActionLink("Добавить", "Create", null, new { @class = "adminLink" })%>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>

