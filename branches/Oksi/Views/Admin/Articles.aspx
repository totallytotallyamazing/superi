<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Oksi.Models.Article>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["pageTitle"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= ViewData["pageTitle"] %></h2>

    <table>
        <tr>
            <th></th>
            <th>
                ����
            </th>
            <th>
                ���������
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("�������������", "Article", new { id=item.Id, news = ViewData["news"] }) %> |
                <%= Html.ActionLink("�������", "DeleteArticle", new { id=item.Id }) %>
            </td>
            <td>
                <%= item.Date.ToShortDateString() %>
            </td>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("�������", "Article", new { id = 0, news = ViewData["news"] })%>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

