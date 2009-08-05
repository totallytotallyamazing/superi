<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Zamov.Models.Order>" %>
<%@ Import Namespace="Zamov.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ShowOrder
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ShowOrder</h2>
Заказ № <%=Html.Encode(Model.Id) %>
    <fieldset>
        <legend>Fields</legend>
        <p>
            Клиент:
            <%= Html.Encode(Model.ClientName)%>
        </p>
        <p>
            Телефон:
            <%= Html.Encode(Model.Phone)%>
        </p>
        <p>
            Дата и время доставки:
            <%= Html.Encode(String.Format("{0:g}", Model.DeliveryDate)) %>
        </p>
        <p>
            Email:
        </p>
        <p>
            Адрес доставки:
            <%= Html.Encode(Model.Address) %>
        </p>
    </fieldset>
    
    <table class="commonTable">
        <tr>
            <th></th>
            <th>Код товара</th>
            <th>Наименование</th>
            <th>Количество</th>
            <th>Цена</th>
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
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

