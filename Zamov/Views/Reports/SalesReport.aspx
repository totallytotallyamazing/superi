<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SalesReportItem>>" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Замовлення
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table border="1">
        <tr>
            <th><%= Html.SortHeader("NumberIndex", "/Reports/SalesReport", "OrderId", null, null) %></th>
            <th><%= Html.SortHeader("Dealer", "/Reports/SalesReport", "DealerName", null, null) %></th>
            <th><%= Html.SortHeader("Price", "/Reports/SalesReport", "TotalPrice", null, null) %>, грн.</th>
            <th><%= Html.SortHeader("Date", "/Reports/SalesReport", "OrderDate", null, null) %></th>
            <th><%= Html.SortHeader("DeliveryDateTime", "/Reports/SalesReport", "DeliveryDate", null, null)%></th>
            <th><%= Html.SortHeader("Login", "/Reports/SalesReport", "UserName", null, null)%></th>
            <th><%= Html.SortHeader("Client", "/Reports/SalesReport", "ClientName", null, null)%></th>
            <th><%= Html.SortHeader("City", "/Reports/SalesReport", "City", null, null)%></th>
            <th><%= Html.SortHeader("DeliveryAddress", "/Reports/SalesReport", "Address", null, null)%></th>
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
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTop" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="dealerLogo" runat="server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="ContentBottom" runat="server">
</asp:Content>
