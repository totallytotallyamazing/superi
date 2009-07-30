<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>
<%@ Import Namespace="Zamov.Models" %>
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

    <% foreach (Order order in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(order.Id)%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", order.Date))%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", order.DeliveryDate))%>
            </td>
            <td>
                <%= Html.Encode(order.Status)%>
            </td>
            <td>
                <%= Html.Encode(order.OrderItems.Count)%>
            </td>
        </tr>
 
 
    <%
    foreach (OrderItem orderItem in order.OrderItems)
    {
        %>
        
        <tr>
            <td><%=Html.Encode(orderItem.Price)%></td>
        </tr>
        
        <%
        
    } 
    %>
 
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

