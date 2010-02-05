<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SalesReportItem>>" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Замовлення
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form method="get">
        <table>
            <tr>
                <td>
                    Продавець:
                </td>
                <td><%= Html.DropDownList("dealerId") %></td>
                <td style="width:100px;"></td>
                <td>Замовник</td>
                <td><%= Html.TextBox("userName") %></td>
            </tr>
            <tr>
                <td>
                    Мiсто:
                </td>
                <td><%= Html.TextBox("city") %></td>
                <td></td>
                <td>Статус замовлення</td>
                <td><%= Html.DropDownList("orderState")%></td>
            </tr>
        </table>
        <input type="submit" value="Фiльтрувати" />
    </form>
    <table class="blueHeaderedTable">
        <tr class="blueHeader">
            <th><%= Html.SortHeader("NumberIndex", "/Reports/SalesReport", "OrderId", (string)ViewData["filterString"], null) %></th>
            <th><%= Html.SortHeader("Dealer", "/Reports/SalesReport", "DealerName", (string)ViewData["filterString"], null)%></th>
            <th><%= Html.SortHeader("Price", "/Reports/SalesReport", "TotalPrice", (string)ViewData["filterString"], null)%>, грн.</th>
            <th><%= Html.SortHeader("Date", "/Reports/SalesReport", "OrderDate", (string)ViewData["filterString"], null)%></th>
            <th><%= Html.SortHeader("DeliveryDateTime", "/Reports/SalesReport", "DeliveryDate", (string)ViewData["filterString"], null)%></th>
            <th><%= Html.SortHeader("Login", "/Reports/SalesReport", "UserName", (string)ViewData["filterString"], null)%></th>
            <th><%= Html.SortHeader("Client", "/Reports/SalesReport", "ClientName", (string)ViewData["filterString"], null)%></th>
            <th><%= Html.SortHeader("City", "/Reports/SalesReport", "City", (string)ViewData["filterString"], null)%></th>
            <th><%= Html.SortHeader("DeliveryAddress", "/Reports/SalesReport", "Address", (string)ViewData["filterString"], null)%></th>
        </tr>
        <% foreach (var item in Model)
           {%>
                <tr>
                    <td><%= item.OrderId %></td>
                    <td><%= item.DealerName %></td>
                    <td><%= item.TotalPrice %></td>
                    <td><%= item.OrderDate %></td>
                    <td><%= item.DeliveryDate %></td>
                    <td><%= item.UserName %></td>
                    <td><%= item.ClientName %></td>
                    <td><%= item.City %></td>
                    <td><%= item.Address %></td>
                </tr>      
         <%} %>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" type="text/css" href="/Content/reports.css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTop" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="dealerLogo" runat="server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="ContentBottom" runat="server">
</asp:Content>
