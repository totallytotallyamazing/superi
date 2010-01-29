<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SalesReportItem>>" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	����������
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table border="1">
        <tr>
            <th><%= Html.SortHeader("NumberIndex", "/Reports/SalesReport", "OrderId", null, null) %></th>
            <th>���������</th>
            <th>����i���, ���.</th>
            <th>���� ����������</th>
            <th>���� i ��� ��������</th>
            <th>���i�</th>
            <th>��������</th>
            <th>�i���</th>
            <th>������</th>
            <th>������</th>
        </tr>
        <% foreach (var item in Model)
           {%>
                <tr>
                    <td><%= item.OrderId %></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
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
