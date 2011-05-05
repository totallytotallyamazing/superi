<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Oksi.Models.Banner>>" %>

<%@ Import Namespace="Oksi.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Banners
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%

    string[] bannerPositions = {"Неактивный", "Слева", "Справа"};
    
     %>
    <h2>Баннеры</h2>
    <table>
        <tr>
            <th>
                Баннер
            </th>
            <th>
                Позиция
            </th>
            <th>
            </th>
        </tr>
        <%
            int cnt = 0;
            foreach (var item in Model)
            {
                cnt++; %>
        
        <tr>
            <td>
                <%=Html.RegisterFlashScript(item.ImageSource, "b_"+cnt, 100, 100)%>
            </td>
            <td>
                <%=bannerPositions[item.Position]%>
            </td>
            <td>
                <%= Html.ActionLink("Редактировать", "BannerAddEdit", new { id=item.id }) %>
                |
                <%= Html.ActionLink("Удалить", "DeleteBanner", new { id=item.id },new{onclick="return confirm('Вы уыерены, что хотите удалить этот баннер?')"})%>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%= Html.ActionLink("Добавить", "BannerAddEdit")%>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>
