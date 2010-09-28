<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.OrderItem>>" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<script type="text/javascript">
     function alignTotal() {
         var w = $("#totalAmount").width();
         var tw = $("#totalAmount .left").width();
         var m = 1 * (w - tw) / 2;
         $("#totalAmount .left, #totalAmount .totalLabel").css("left", m + "px").css("position", "relative");
     }
</script>


<% foreach (var item in Model){%>
        <%--<tr>
            <td valign="top" class="productImage">
                <%= Html.CachedImage("~/Content/ProductImages", item.Image, "cartThumb", "")%>
            </td>
            <td class="name" valign="top">
                <div class="name">
                    <%= Html.ActionLink(item.Name, "Show", new { controller="Products", area="", id=item.Id})%>
                </div>  
                <div class="description">
                    <%= item.Description %>
                </div>
            </td>
            <td class="quantity" valign="top">
                <%= Html.TextBox("oi_" + item.ProductId, item.Quantity) %>
            </td>
            <td class="price" valign="top" id="Td1">
                <%= Html.RenderPrice(item.Price * item.Quantity, WebSession.Currency, 0, ",") %>
            </td>
            <td class="delete" valign="top">
                <%= Html.ActionLink("[IMAGE]", "Delete", new { id=item.ProductId }).ToString()
                    .Replace("[IMAGE]", "<img style=\"border:0\" src=\"/Content/img/deleteFromCart.jpg\" alt=\"Удалить\" />") %>
            </td>
        </tr>--%>
   

<div id="orderItem">
        <div id="priceOrderItem">
        <div class="price">
            <p class="ort1"><%= Html.RenderPrice(item.Price * item.Quantity, WebSession.Currency, 0, ",") %></p>
        </div>
        </div>
        <div id="imgOrderItem">
            <%= Html.CachedImage("~/Content/ProductImages", item.Image, "cartThumb", "")%>
        </div>
        <div id="txtOrderItem">
            <div id="nameOrderItem">
                <b><%= Html.ActionLink(item.Name, "Show", new { controller = "Products", area = "", id = item.Id }, new { @class = "it1" })%></b> <br />
            </div>
            <p class="ort2"><%= item.Description %>
            </p>
            <div id="removeOrderItem">    
                <div id="crossOrderItem">
                    <img src="../../Content/UnMomentoStyles/img/cross.gif" alt="Убрать из корзинки" />    
                </div>
                <div id="txtRemoveOrderItem">
                    <a href="#" class="nt1">Убрать из корзинки</a>    
                </div>
            </div>           
        </div>
    </div>


 <%} %>
 <div id="payment">
        <p class="opt1">=</p>         <div class="price">        <p class="opt2"><%= Html.RenderPrice((float)ViewData["totalAmount"], WebSession.Currency, 0, ",") %>  </p>        </div>        <p class="opt3">к оплате</p>
        
    </div>





   <%-- <table id="cartContents">
    <tr>
        <th></th>
        <th></th>
        <th valign="top">
            <div>
                Кол-во, шт
            </div>
        </th>
        <th valign="top">
            <div>
                Стоимость
            </div>
        </th>
        <th valign="top">
            <div>
                Удалить
            </div>
        </th>
    </tr>
    <% foreach (var item in Model){%>
        <tr>
            <td valign="top" class="productImage">
                <%= Html.CachedImage("~/Content/ProductImages", item.Image, "cartThumb", "")%>
            </td>
            <td class="name" valign="top">
                <div class="name">
                    <%= Html.ActionLink(item.Name, "Show", new { controller="Products", area="", id=item.Id})%>
                </div>  
                <div class="description">
                    <%= item.Description %>
                </div>
            </td>
            <td class="quantity" valign="top">
                <%= Html.TextBox("oi_" + item.ProductId, item.Quantity) %>
            </td>
            <td class="price" valign="top" id="price_<%= item.ProductId %>">
                <%= Html.RenderPrice(item.Price * item.Quantity, WebSession.Currency, 0, ",") %>
            </td>
            <td class="delete" valign="top">
                <%= Html.ActionLink("[IMAGE]", "Delete", new { id=item.ProductId }).ToString()
                    .Replace("[IMAGE]", "<img style=\"border:0\" src=\"/Content/img/deleteFromCart.jpg\" alt=\"Удалить\" />") %>
            </td>
        </tr>
    <%} %>
        <tr>
            <td colspan="3">&nbsp;</td>
            <td id="totalAmount">
                <div class="left">
                    <div class="right">
                        <div class="bg">
                            <%= Html.RenderPrice((float)ViewData["totalAmount"], WebSession.Currency, 0, ",") %>
                        </div>
                    </div>
                </div>
                <div class="totalLabel">Итого:</div>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>--%>
    
    <%--<div id="totalLine">
    
    </div>--%>