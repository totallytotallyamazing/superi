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
        <table class="tableOrders" border="1">
        <tr>
            <td>Номер</td>
            <td><%= Html.Encode(order.Id)%></td>
        </tr>
        <tr>
            <td>Дата</td>
            <td><%= Html.Encode(order.Date.ToShortDateString())%></td>
        </tr>
        <tr>
            <td>Дата доставки</td>
            <td><%= Html.Encode(((DateTime)order.DeliveryDate).ToShortDateString())%></td>
        </tr>
        <tr>
            <td>Статус</td>
            <td><%= Html.Encode(order.Status)%></td>
        </tr>
        <tr>
            <td>Количество заказов</td>
            <td><%= Html.Encode(order.OrderItems.Count)%></td>
        </tr>
        <tr>
            <td colspan="2" style="padding:1px;">
                <table class="tableOrderItems" border="1">
                <tr>
                    <td>Номер:</td>
                    <td>Название:</td>
                    <td>Артикул:</td>
                    <td>Цена:</td>
                </tr>
            <%
            foreach (OrderItem orderItem in order.OrderItems)
            {
                %>
                <tr>
                    <td align="center"><%=Html.Encode(orderItem.Id)%></td>
                    <td><%=Html.Encode(orderItem.Name)%></td>
                    <td><%=Html.Encode(orderItem.PartNumber)%></td>
                    <td><%=Html.Encode(orderItem.Price)%></td>
                </tr>
                <%
            } 
            %>
                </table>
         </td>
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

