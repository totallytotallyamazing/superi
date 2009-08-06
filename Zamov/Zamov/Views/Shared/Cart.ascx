<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%
    Cart cart = SystemSettings.Cart;
    decimal totalPrice = cart.Orders.Sum(o => o.OrderItems.Sum(oi => (oi.Price * oi.Quantity)));
    int orderItemsCount = cart.Orders.Sum(o => o.OrderItems.Sum(oi => oi.Quantity));

    string emptyCartUrl = Url.Action("EmptyCart", "Cart");
    string makeOrderUrl = Url.Action("MakeOrder", "Cart");
    string cartUrl = Url.Action("Index", "Cart");
%>

<div class="cartContainer">
    <table class="cartTable">
        <tr>
            <th>
                <%= Html.ResourceString("EmptyCart") %>
            </th>    
            <th>
                <%= Html.ResourceString("CartItemsCount") %>
            </th>
            <th>
                <%= Html.ResourceString("PurchaseTotalPrice")%>
            </th>
            <th>
                <%= Html.ResourceString("MakeOrder") %>
            </th>
        </tr>
        <tr>
            <td>
                <a href="<%= emptyCartUrl %>">
                    <%= Html.Image("~/Content/img/crossMark.jpg", new { style="border:none" })%>
                </a>
            </td>
            <td style="padding-top:0px;">
                <div onclick="location.href = '<%= cartUrl %>'">
                    <%= orderItemsCount %>
                </div>
            </td>
            <td valign="middle">
                <%= totalPrice %>
            </td>
            <td>
                <a href="<%= makeOrderUrl %>">
                    <%= Html.Image("~/Content/img/tickMark.jpg", new { style = "border:none" })%>
                </a>
            </td>
        </tr>
        <tr>
            <td></td>
            <td valign="top" style="padding-top:0px;">
                <%= Html.Image("~/Content/img/cartShadow.jpg") %>
            </td>
            <td></td>
            <td></td>
        </tr>
    </table>
</div>
