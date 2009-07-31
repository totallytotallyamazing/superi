<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>
<%@ Import Namespace="Zamov.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ShowCart
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>ShowCart</h2>
    <table>
    <% foreach (Order order in Model) { %>
    <tr>
        <td>
        <%=Html.Encode(order.Dealers.Name)%>
        <table class="commonTable" border="1">
        <tr>
            <th>Наименование</th>
            <th>Фото</th>
            <th>Единица измерения</th>
            <th>Цена грн.</th>
            <th>Кол-во</th>
            <th>Стоимость грн.</th>
        </tr>
        <%
        foreach (OrderItem orderItem in order.OrderItems)
        {
        %>
        <tr>
            <td><%=Html.Encode(orderItem.Name)%></td>
            <td></td>
            <td></td>
            <td><%=Html.Encode(orderItem.Price)%></td>
            <td></td>
            <td></td>
        </tr>
        <%
        }
            
        %>
        <tr>
            <td colspan="3"></td>
            <td>Всего</td>
            <td><%=order.OrderItems.Count%></td>
            <td><%=order.OrderItems.Sum(oi=>oi.Price)%></td>
        </tr>
         </table>   
        </td>            
        </tr>            
        <tr>
        <td style="padding-top:10px;">
        &nbsp;
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

