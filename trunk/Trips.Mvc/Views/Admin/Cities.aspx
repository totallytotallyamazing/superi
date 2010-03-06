<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Trips.Mvc.Models.City>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Города
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>
                Русский
            </th>
            <th>
                Английский
            </th>
            <th></th>
            <th></th>
        </tr>

    <% foreach (var item in Model) {
           string nameEn = item.CityNames.Where(cn => cn.Language == "en-US").First().Name;
           string nameRu = item.CityNames.Where(cn => cn.Language == "ru-RU").First().Name;
           %>
        <%using(Html.BeginForm("UpdateCity", "Admin")){ %>
        <tr>
            <td>
                <%= Html.TextBox("nameRu", nameRu)%>
            </td>
            <td>
                <%= Html.TextBox("nameEn", nameEn)%>
            </td>
            <td>
                <%= Html.Hidden("id", item.Id) %>
                <input type="submit" value="Сохранить" />
            </td>
            <td>
                <%= Html.ActionLink("Удалить", "DeleteCity", new {id=item.Id}) %>
            </td>
        </tr>
        <%} %>
    <% } %>

    </table>

    <%using(Html.BeginForm("AddBrand", "Admin")){ %>
        <table>
            <tr>
                <th>
                    Русский
                </th>
                <th>
                    Английский
                </th>
                <th></th>
            </tr>
            <tr>
                <td>
                    <%= Html.TextBox("nameRu") %>
                </td>
                <td>
                    <%= Html.TextBox("nameEn") %>
                </td>
                <td>
                    <input type="submit" value="Добавить" />
                </td>
            </tr>
        </table>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    Города
</asp:Content>

