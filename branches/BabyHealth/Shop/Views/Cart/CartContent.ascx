<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.OrderItem>>" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

    <table id="cartContents">
    <tr>
        <th></th>
        <th></th>
        <th>
            Кол-во, шт
        </th>
        <th>
            Стоимость
        </th>
        <th>
            Удалить
        </th>
    </tr>
    <% foreach (var item in Model){%>
        <tr>
            <td>
                <%= Html.CachedImage("~/Content/ProductImages", item.Image, "cartThumb", "")%>
            </td>
            <td>
                <div>
                    <h2><%= item.Name %></h2>
                </div>  
                <div>
                    <%= item.Description %>
                </div>
            </td>
            <td>
                <%= Html.TextBox("oi_" + item.ProductId, item.Quantity) %>
            </td>
            <td id="price_<%= item.ProductId %>">
                <%= Html.RenderPrice(item.Price * item.Quantity, WebSession.Currency, 0, ",") %>
            </td>
            <td>
                <%= Html.ActionLink("[IMAGE]", "Delete", new { id=item.ProductId }).ToString()
                    .Replace("[IMAGE]", "<img style=\"border:0\" src=\"/Content/img/deleteFromCart.jpg\" alt=\"Удалить\" />") %>
            </td>
        </tr>
    <%} %>
        <tr class="totalLine">
            <td colspan="3"></td>
            <td id="totalAmount">
                <%= Html.RenderPrice((float)ViewData["totalAmount"], WebSession.Currency, 0, ",") %>
            </td>
            <td></td>
        </tr>
    </table>