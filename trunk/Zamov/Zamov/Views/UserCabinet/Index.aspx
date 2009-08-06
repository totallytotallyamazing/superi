<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>
<%@ Import Namespace="Zamov.Helpers"%>
<%@ Import Namespace="Zamov.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
        var items = new Array();
        $(function() {
            $(".cartDescription")
            .fancybox(
            {
                frameWidth: 700,
                //frameHeight: 500,
                hideOnContentClick: false
            });
        })
    </script>
История Ваших покупок/сохраненные Вами корзины
    <table class="commonTable">
        <tr>
            <th>№</th>
            <th><%=Html.ResourceString("CartName")%></th>
            <th><%=Html.ResourceString("Dealer")%></th>
            <th><%=Html.ResourceString("Date")%></th>
            <th><%=Html.ResourceString("Cost")%>, грн</th>
            <th></th>
            <th><%=Html.ResourceString("OrderStatus")%></th>
            <th></th>
        </tr>
    <%

        int PrevId=0;
        foreach (Order order in Model) 
        {
        int NextId=order.Cart.Id;
        int c = order.OrderItems.Count;
        if (PrevId != NextId)
        {
        %>
        <tr>
            <td rowspan="<%=Html.Encode(c)%>"><%=Html.Encode(order.Cart.Id)%></td>
            <td rowspan="<%=Html.Encode(c)%>"><%=Html.Encode(order.Cart.Name)%></td>
            <td><%=Html.Encode(order.Dealer.Name)%></td>
            <td rowspan="<%=Html.Encode(c)%>"><%=Html.Encode(String.Format("{0:dd.MM.yyyy HH:mm}", order.Cart.Date))%></td>
            <td><%=Html.Encode(order.OrderItems.Sum(oi => oi.Price))%></td>
            <td rowspan="<%=Html.Encode(c)%>"><%=Html.ActionLink(Html.ResourceString("View"), "ShowCart", new { id = order.Cart.Id }, new { @class = "cartDescription" })%></td>
            <td><%=Html.Encode(Status.status[order.Status])%></td>
            <td  rowspan="<%=Html.Encode(c)%>"><%=Html.ActionLink(Html.ResourceString("Delete"), "DeleteCart", new { id = order.Cart.Id }, new { onclick = "return confirm('" + Html.ResourceString("AreYouSure") + "?')" })%></td>
        </tr>
        <%
        }
        else
        {
            %>
            <tr>
                <td><%=Html.Encode(order.Dealer.Name)%></td>
                <td><%=Html.Encode(order.OrderItems.Sum(oi => oi.Price))%></td>
                <td><%=Html.Encode(Status.status[order.Status])%></td>
            </tr>
            
            <%
        }
            PrevId = NextId;
    }   %>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterJS("jquery.easing.js")%>
    <%= Html.RegisterJS("jquery.fancybox.js")%>
    <%= Html.RegisterCss("~/Content/fancy/jquery.fancybox.css")%>
</asp:Content>