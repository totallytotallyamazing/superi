<%@ Page Title="" Language="C#" MasterPageFile="~/Views/DealerCabinet/Cabinet.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>
<%@ Import Namespace="Zamov.Models"%>
<%@ Import Namespace="Zamov.Helpers"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Orders
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
        var items = new Array();
        $(function() {
            $(".orderDescription")
            .fancybox(
            {
                frameWidth: 700,
                //frameHeight: 500,
                hideOnContentClick: false
            });
        })
    </script>
    <h2>Orders</h2>

    <table class="commonTable">
        <tr>
            <th>
                ¹ <%=Html.ResourceString("OfOrder")%>
            </th>
            <th>
                <%=Html.ResourceString("OrderDeliveryDateTime")%>
            </th>
            <th>
                <%=Html.ResourceString("OrderInfo")%>
            </th>
            <th>
                <%=Html.ResourceString("Status")%>
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
                <%= Html.Encode(item.ClientName+", "+item.Address) %>
            </td>
            <td>
                <%= Html.Encode(Status.status[item.Status]) %>
            </td>
            <td>
                <%=Html.ActionLink(Html.ResourceString("OpenOrder"), "ShowOrder", new { id = item.Id }, new { @class = "orderDescription" })%>
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
