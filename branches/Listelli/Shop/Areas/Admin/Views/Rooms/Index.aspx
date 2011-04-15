<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.DesignerRoom>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Виды помещений
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Виды помещений</h2>

     <table>
    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.Type %>
            </td>
            <td>
                <%: item.Name %>
            </td>
             <td>
                <%= Html.ActionLink("Редактировать", "AddEdit", new { id = item.Id }, new { @class="fancy"})%> |
                <%= Html.ActionLink("Удалить", "Delete", new { id = item.Id }, new { onclick = "return confirm('Вы уверены что хотите удалить запись?')" })%>|
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

