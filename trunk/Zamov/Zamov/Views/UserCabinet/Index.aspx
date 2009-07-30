<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Cart>>" %>
<%@ Import Namespace="Zamov.Helpers"%>



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    

    <table border="1" class="tableCarts">
    <tr>
    <td colspan="5">
    История Ваших покупок/сохраненные Вами корзины
    </td>
    </tr>
        <tr>
            <!--<th></th>-->
            <th>
                Номер
            </th>
            <th>
                Дата
            </th>
            <th>
                Название корзины
            </th>
            <th>
            
            </th>
            <th>
            
            </th>
        </tr>


    <% foreach (var item in Model) { %>
    
        <tr>
            <!--<td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.Id })%>
            </td>-->
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Date)) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
            <%=Html.ActionLink("просмотр", "ShowCart", new { id = item.Id })%>
            </td>
            <td>
            <%=Html.ActionLink("удалить", "DeleteCart", new { id = item.Id }, new { onclick = "return confirm('" + Html.ResourceString("AreYouSure") + "?')" })%>
            </td>
        </tr>
    <% } %>

    </table>
<!--
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
-->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

