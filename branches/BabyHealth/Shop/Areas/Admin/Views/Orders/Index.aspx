<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Order>>" %>
<%@ Import Namespace=" Shop.Models"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Заказы
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="ordersTable" border="1">
        <tr>
            <th></th>
            <th>
                № заказа
            </th>
            <th>
                Время заказа
            </th>
            <th>
                Стоимость
            </th>
            <th>
                Заказчик
            </th>
            <th>
                Телефон
            </th>
            <th>
                Адресс доставки
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Детали", "Details", new { id=item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.OrderDate) %>
            </td>
            <td>
                <%: String.Format("{0:f}", item.OrderItems.GetTotalAmount()) %>
            </td>
            <td>
                <%: item.BillingName %>
            </td>
            <td>
                <%: item.BillingPhone %>
            </td>
            <td>
                <%: item.DeliveryAddress %>
            </td>
        </tr>
    
    <% } %>

    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Заказы
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <style>
        #ordersTable{font-size:10px; width:100%;}
        #ordersTable td{padding-right:10px;}
    </style>
</asp:Content>

