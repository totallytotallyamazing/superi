<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/Manage.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Pandemiia.Models.Tag>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Теги
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <h2>Теги</h2>

    <table>
        <tr>
            <th>
                ID
            </th>
            <th>
                Тег
            </th>
            <th></th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    <% using(Html.BeginForm("SaveTag", "Manage", FormMethod.Post)){ %>
        <tr>
            <td>
                <%= Html.Encode(item.ID) %>
                <%= Html.Hidden("id", item.ID) %>
            </td>
            <td>
                <%= Html.TextBox("tagName", item.TagName) %>
            </td>
            <td>
                <input type="submit" value="Сохранить" />
            </td>
            <td>
                <%= Html.ActionLink("Удалить", "DeleteTag", new { id = item.ID }, new { onclick = "return confirm('Стопудов?')" })%>
            </td>
        </tr>
    <%} %>
    <% } %>

    </table></asp:Content>

