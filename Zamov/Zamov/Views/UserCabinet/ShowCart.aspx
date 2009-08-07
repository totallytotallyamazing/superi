<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>
<%@ Import Namespace="Zamov.Controllers"%>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Helpers"%>
<table border="0">
    <% foreach (Order order in Model) {
    %>
    <tr>
        <td><%Html.RenderAction<UserCabinetController>(ac=>ac.ShowOrder(order));%></td>            
    </tr>            
    <tr>
        <td style="padding-top:10px;">&nbsp;</td>            
    </tr>
    <%
       }
    %>
</table>