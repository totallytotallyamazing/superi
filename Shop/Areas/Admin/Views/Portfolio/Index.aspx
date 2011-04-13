<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Portfolio>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Портфолио дизайнеров</h2>

    <table>
    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.UserName %>
            </td>
             <td>
                <%= Html.ActionLink("Редактировать", "AddEdit", new { id = item.Id }, new { @class="fancy"})%> |
                <%= Html.ActionLink("Удалить", "Delete", new { id = item.Id }, new { onclick = "return confirm('При удалении пользователя, удаляются также все с ним связанные работы. Вы уверены что хотите удалить пользователя?')" })%>|
                <%=Html.ActionLink("К странице пользователя", "Index", "Designers", new {id=item.Id }, null)%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Создать", "AddEdit")%>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>

