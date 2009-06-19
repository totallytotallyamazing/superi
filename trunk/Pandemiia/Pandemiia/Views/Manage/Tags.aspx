<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/Manage.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Pandemiia.Models.Tag>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	����
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <h2>����</h2>

    <table>
        <tr>
            <th>
                ID
            </th>
            <th>
                ���
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
                <input type="submit" value="���������" />
            </td>
            <td>
                <%= Html.ActionLink("�������", "DeleteTag", new { id = item.ID }, new { onclick = "return confirm('��������?')" })%>
            </td>
        </tr>
    <%} %>
    <% } %>

    </table></asp:Content>

