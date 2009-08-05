<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Zamov.Models.Order>" %>
<%@ Import Namespace="Zamov.Helpers"%>
<%@ Import Namespace="Zamov.Models"%>
<div align="center">
<div align="left"  style="padding-left:30px; padding-top:10px;">
    <p>
    <b>����� � <%=Html.Encode(Model.Id) %></b>
   </p>
        <p>
            ������:
            <%= Html.Encode(Model.ClientName)%>
        </p>
        <p>
            �������:
            <%= Html.Encode(Model.Phone)%>
        </p>
        <p>
            ���� � ����� ��������:
            <%= Html.Encode(String.Format("{0:g}", Model.DeliveryDate)) %>
        </p>
        <p>
            Email:
        </p>
        <p>
            ����� ��������:
            <%= Html.Encode(Model.Address) %>
        </p>

    <br />
</div>    
    <table class="commonTable">
        <tr>
            <th></th>
            <th>��� ������</th>
            <th>������������</th>
            <th>����������</th>
            <th>����</th>
        </tr>
    <%

        int cnt = 0;
        decimal allsum = 0;
    foreach (OrderItem orderItem  in Model.OrderItems)
    {
        decimal sum = orderItem.Price * orderItem.Quantity;
        allsum += sum;
        %>
        <tr>
            <td><%=Html.Encode(++cnt)%></td>
            <td><%=Html.Encode(orderItem.PartNumber)%></td>
            <td><%=Html.Encode(orderItem.Name)%></td>
            <td><%=Html.Encode(orderItem.Quantity)%></td>
            <td><%=Html.Encode(sum.ToString("N"))%></td>
        </tr>
        <%
    }
%>
<tr>
    <td colspan="4"></td>
    <td><%=Html.Encode(allsum.ToString("N"))%></td>
</tr>
</table>
<br />
<input type="submit" value="<%=Html.ResourceString("AcceptOrder") %>" />
<%
    using (Html.BeginForm("AcceptOrder","DealerCabinet",FormMethod.Post,new {id="acceptOrder"}))
    {
        %>
        <%=Html.Hidden("orderId",Model.Id) %>
        <%
    } 
%>
</div>
