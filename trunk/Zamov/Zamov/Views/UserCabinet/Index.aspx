<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>
<%@ Import Namespace="Zamov.Helpers"%>
<%@ Import Namespace="Zamov.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
История Ваших покупок/сохраненные Вами корзины
    <table class="commonTable">
        <tr>
            <th>№</th>
            <th>Название корзины</th>
            <th>Поставщик</th>
            <th>Дата</th>
            <th>Сумма, грн</th>
            <th></th>
            <th>Статус заказа</th>
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
            <td rowspan="<%=Html.Encode(c)%>"><%=Html.ActionLink("просмотр", "ShowCart", new {id = order.Cart.Id})%></td>
            <td><%=Html.Encode(order.Status)%></td>
            <td  rowspan="<%=Html.Encode(c)%>"><%=Html.ActionLink("удалить", "DeleteCart", new {id = order.Cart.Id},new{onclick ="return confirm('" + Html.ResourceString("AreYouSure") + "?')"})%></td>
        </tr>
        <%
        }
        else
        {
            %>
            <tr>
                <td><%=Html.Encode(order.Dealer.Name)%></td>
                <td><%=Html.Encode(order.OrderItems.Sum(oi => oi.Price))%></td>
                <td><%=Html.Encode(order.Status)%></td>
            </tr>
            
            <%
        }
            PrevId = NextId;
    }   %>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

