<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>
<%@ Import Namespace="Zamov.Models" %>
<table border="0">
    <% foreach (Order order in Model) { %>
    <tr>
        <td>
        <%=Html.Encode(order.Dealer.Name)%>
        <table class="commonTable">
        <tr>
            <th>������������</th>
            <th>����</th>
            <th>������� ���������</th>
            <th>���� ���.</th>
            <th>���-��</th>
            <th>��������� ���.</th>
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
            <td>�����</td>
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