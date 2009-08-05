<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>
<%@ Import Namespace="Zamov.Helpers"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Orders
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
        var items = new Array();
        $(function() {
            $(".orderDescription").fancybox({ frameWidth: 700, frameHeight: 500 });
        })
    </script>
    <h2>Orders</h2>

    <table class="commonTable">
        <tr>
            <th>
                № заказа
            </th>
            <th>
                Дата и время доставки
            </th>
            <th>
                Информация о клиенте, заказе и доставке
            </th>
            <th>
                Статус
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.DeliveryDate)) %>
            </td>
            <td>
                <%= Html.Encode(item.Address) %>
            </td>
            <td>
                <%= Html.Encode(item.Status) %>
            </td>
            <td>
                <a class="orderDescription" href="/DealerCabinet/ShowOrder/<%=item.Id%>">просмотр</a>
            </td>
        </tr>
    
    <% } %>

    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterJS("jquery.easing.js")%>
    <%= Html.RegisterJS("jquery.fancybox.js")%>
    <%= Html.RegisterCss("~/Content/fancy/jquery.fancybox.css")%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

