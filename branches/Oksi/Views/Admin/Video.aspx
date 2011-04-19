<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Oksi.Models.Clip>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Video
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Video</h2>

    <table>
        <tr>
            <th>
                ���������
            </th>
            <th>
                ������� �����������
            </th>
            <th>
                ��������
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
            <td>
                <%= Html.Encode(item.SortOrder) %>
            </td>
            <td>
                <%= Html.Encode(item.Description) %>
            </td>
             <td>
                <%= Html.ActionLink("�������������", "EditVideo", new { id=item.Id }) %>|
                <%= Html.ActionLink("�������", "DeleteVideo", new { id=item.Id },new{onclick="return confirm('�� �������, ��� ������ ������� ������?')"}) %>
            </td>
        </tr>
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("�������� ������", "CreateVideo") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>

