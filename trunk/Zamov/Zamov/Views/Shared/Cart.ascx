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
    string cartUrl = Url.Action("Index", "Cart", new { id = ViewData["dealerId"] });
    string action = (string)ViewContext.RouteData.Values["action"];
    string controller = (string)ViewContext.RouteData.Values["controller"];
    CartHostActions hostAction = CartHostActions.Other;

    if (controller.ToUpperInvariant() == "PRODUCTS")
        hostAction = CartHostActions.Products;
    else if (controller.ToUpperInvariant() == "CART")
    {
        if (action.ToUpperInvariant() == "INDEX")
            hostAction = CartHostActions.Cart;
        else if (action.ToUpperInvariant() == "MAKEORDER")
            hostAction = CartHostActions.MakeOrder;
    }
    else
        hostAction = CartHostActions.Other;

    bool displayCartContainer = (orderItemsCount > 0 && cart.Id == 0) || hostAction != CartHostActions.Other;

%>

<%if(!displayCartContainer){ %>
<script type="text/javascript">
    $(function() { $(".subHeader").css("display", "none"); });
</script>
<%} %>
<div class="cartContainer">
    <table class="cartTable">
        <tr>
            <th>
                <%= Html.ResourceString("EmptyCart") %>
            </th>
            <th>
                <%= Html.ResourceString("CartItemsCount")%>
            </th>
            <th>
                <%= Html.ResourceString("PurchaseTotalPrice")%>
            </th>
            <%if(hostAction!= CartHostActions.MakeOrder){ %>
            <th>
                <%= Html.ResourceString("MakeOrder") %>
            </th>
            <%} %>
        </tr>
        <tr>
            <td>
                <a href="/Cart/EmptyCart/?dealerId=<%= ViewData["dealerId"] %>&groupId=<%= ViewData["groupId"]%>" onclick="return confirm('<%= Html.ResourceString("AreYouSure")%>')" >
                    <img style="border:none" alt="emptyCart" src="/Content/img/crossMark.jpg" />
                </a>
            </td>
            <td style="padding-top:0px;">
                <div id="orderItemsCount" onclick="<%= (hostAction == CartHostActions.Cart)?"return false; " : "" %>location.href = '<%= cartUrl %>'" style="margin:0 auto" <%= (hostAction == CartHostActions.Cart)?"class=\"cartDisabled\"":""%>>
                    <%= orderItemsCount%>
                </div>
            </td>
            <td valign="middle" id="totalPrice">
                <%= totalPrice.ToString("N") %>
            </td>
            <%if(hostAction!= CartHostActions.MakeOrder){ %>
            <td>
                <a href="<%= makeOrderUrl %>">
                    <%= Html.Image("~/Content/img/tickMark.jpg", new { style = "border:none" })%>
                </a>
            </td>
            <%} %>
        </tr>
        <tr>
            <td></td>
            <td valign="top" style="padding-top:0px;">
                <%= Html.Image("~/Content/img/cartShadow.jpg") %>
            </td>
            <td></td>
            <%if(hostAction!= CartHostActions.MakeOrder){ %>
            <td></td>
            <%} %>
        </tr>
    </table>
</div>
