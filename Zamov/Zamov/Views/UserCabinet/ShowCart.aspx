<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>
<%@ Import Namespace="Zamov.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ShowCart
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>ShowCart</h2>
    <table border="0">
    <% foreach (Order order in Model) { %>
    <tr>
        <td>
        <%=Html.Encode(order.Dealer.Name)%>
        <table class="commonTable">
        <tr>
            <th>Наименование</th>
            <th>Фото</th>
            <th>Единица измерения</th>
            <th>Цена грн.</th>
            <th>Кол-во</th>
            <th>Стоимость грн.</th>
        </tr>
        <%
        
        decimal allsum = 0;   
        foreach (OrderItem orderItem in order.OrderItems)
        {
            
            decimal sum = orderItem.Quantity * orderItem.Price;
            allsum += sum;
        %>
        <tr>
            <td><%=Html.Encode(orderItem.Name)%></td>
            <td></td>
            <td></td>
            <td><%=Html.Encode(orderItem.Price)%></td>
            <td><%=Html.Encode(orderItem.Quantity)%></td>
            <td><%=Html.Encode(sum.ToString("N"))%></td>
        </tr>
        <%
        }
            
        %>
        <tr>
            <td colspan="3"></td>
            <td>Всего</td>
            <td><%=Html.Encode(order.OrderItems.Sum(oi=>oi.Quantity))%></td>
            <td><%=Html.Encode(allsum.ToString("N"))%></td>
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

