<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Zamov.Models.Order>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Helpers"%>


        <%= Html.Image("~/Image/ShowLogo/" + Model.Dealer.Id, new { style="border:1px solid #ccc;" })%>  
        <table class="commonTable">
        <tr>
            <th><%=Html.ResourceString("Title")%></th>
            <th>‘ото</th>
            <th><%=Html.ResourceString("Unit")%></th>
            <th><%=Html.ResourceString("Price")%></th>
            <th><%=Html.ResourceString("Quantity")%></th>
            <th><%=Html.ResourceString("Cost")%> грн.</th>
        </tr>
        <%
        
        decimal allsum = 0;   
        foreach (OrderItem orderItem in Model.OrderItems)
        {
            decimal sum = orderItem.Quantity * orderItem.Price;
            allsum += sum;
        %>
        <tr>
            <td><%=Html.Encode(orderItem.Name)%></td>
            <td></td>
            <td><%=Html.Encode(orderItem.Unit.Name)%></td>
            <td><%=Html.Encode(orderItem.Price)%></td>
            <td><%=Html.Encode(orderItem.Quantity)%></td>
            <td><%=Html.Encode(sum.ToString("N"))%></td>
        </tr>
        <%
        }
            
        %>
        <tr>
            <td colspan="3"></td>
            <td><%=Html.ResourceString("Total") %></td>
            <td><%=Html.Encode(Model.OrderItems.Sum(oi=>oi.Quantity))%></td>
            <td><%=Html.Encode(allsum.ToString("N"))%></td>
        </tr>
         </table>   
        
        

