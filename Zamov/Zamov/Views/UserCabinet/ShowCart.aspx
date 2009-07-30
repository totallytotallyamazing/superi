<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ShowCart
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ShowCart</h2>

    <table>
        <tr>
            <th>
                Номер
            </th>
            <th>
                Дата
            </th>
            <th>
                Дата доставки
            </th>
            <th>
                Статус
            </th>
            <th>
                Количество заказов
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Date)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.DeliveryDate)) %>
            </td>
            <td>
                <%= Html.Encode(item.Status) %>
            </td>
            <td>
                <%= Html.Encode(item.OrderItems.Count) %>
            </td>
        </tr>
 
    <% } %>
    </table>
    
       <div>
        <%=Html.ActionLink("Назад", "../UserCabinet")%>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

