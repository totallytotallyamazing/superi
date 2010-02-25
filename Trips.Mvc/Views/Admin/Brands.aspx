<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Trips.Mvc.Models.Brand>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Brands
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Brands</h2>

    <table>
        <tr>
            <th>
                �����
            </th>
            <th>
                ����������
            </th>
            <th></th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
        <%using(Html.BeginForm("UpdateBrand", "Admin")){ %>
        <tr>
            <td>
                <%= Html.TextBox("name", item.Name) %>
            </td>
            <td>
                <%= Html.CheckBox("published", item.Published) %>
            </td>
            <td>
                <%= Html.Hidden("id", item.Id) %>
                <input type="submit" value="���������" />
            </td>
            <td>
                <%= Html.ActionLink("�������", "DeleteBrand", new {id=item.Id}) %>
            </td>
        </tr>
        <%} %>
    <% } %>

    </table>

    <%using(Html.BeginForm("AddBrand", "Admin")){ %>
        <table>
            <tr>
                <th>
                    �����
                </th>
                <th>
                    ����������
                </th>
                <th></th>
            </tr>
            <tr>
                <td>
                    <%= Html.TextBox("name") %>
                </td>
                <td>
                    <%= Html.CheckBox("published", false) %>
                </td>
                <td>
                    <input type="submit" value="��������" />
                </td>
            </tr>
        </table>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

