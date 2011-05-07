<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.DesignerContent>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Виды помещений
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Виды помещений</h2>
    <%=Html.Hidden("designerId")%>
    <%
        int dId = (int)ViewData["designerId"];
    %>
    <table class="editRoomsTable">
        <tr>
           
            <th>
                Название
            </th>
            <th>
                Вид
            </th>
             <th>
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
           
            <td>
                <%: item.RoomName %>
            </td>
            <td>
                <%=(item.RoomType==0?"Жилые помещения":"Нежилые помещения") %>
            </td>
             <td>
                <%: Html.ActionLink("Редактировать", "AddEditRoom", new { designerId = dId, id = item.Id })%>
                |
                <%= Html.ActionLink("Удалить", "DeleteRoom", new { id = item.Id,designerId=dId }, new { onclick = "return confirm('При удалении помещения, удаляются также все с ним связанные работы. Вы уверены что хотите удалить помещение?')" })%>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Создать новое помещение", "AddEditRoom", new { designerId = dId })%>
    </p>
    
    <p>
        <%: Html.ActionLink("« К списку дизайнеров", "Index", null, new {@class="toList" })%>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
