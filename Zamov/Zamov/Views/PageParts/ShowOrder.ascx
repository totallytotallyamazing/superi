<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Zamov.Models.Order>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%
    bool cartMode = (ViewData["cartMode"] != null);
%>

<script type="text/javascript">
    var showOrdershadowsDeclared = false;
    if (!showOrdershadowsDeclared) {
        $(function() {
            applyDropShadows(".dealerImageLogo", "shadow3");
            $(".productDescription").fancybox({ frameWidth: 700, frameHeight: 500 });
        })
        showOrdershadowsDeclared = true;
    }
</script>

<%= Html.Image("~/Image/ShowLogo/" + Model.Dealer.Id, new { style="border:1px solid #ccc;", @class="dealerImageLogo" })%>
<table class="commonTable">
    <tr>
        <th>
            <%=Html.ResourceString("Title")%>
        </th>
        <th>
            ‘ото
        </th>
        <th>
            <%=Html.ResourceString("Unit")%>
        </th>
        <th>
            <%=Html.ResourceString("Price")%>
        </th>
        <th>
            <%=Html.ResourceString("Quantity")%>
        </th>
        <th>
            <%=Html.ResourceString("Cost")%>
            грн.
        </th>
        <%if (cartMode){ %>
        <th></th>
        <%} %>
    </tr>
    <%
        
        decimal total = 0;
        foreach (OrderItem orderItem in Model.OrderItems)
        {
            decimal sum = orderItem.Quantity * orderItem.Price;
            total += sum;
    %>
    <tr>
        <td>
            <%=Html.Encode(orderItem.Name)%>
        </td>
        <td>
            <a class="productDescription" style="text-decoration:none" href="/Products/Description/<%= orderItem.ProductId %>" <%= (orderItem.ProductId==null)?"disabled":"" %>>
                <%= Html.Image("~/Content/img/productImage.JPG", new { style="border:none;" })%> / <span class="productDescriptionLink">i</span>
            </a>
        </td>
        <td>
            <%=Html.Encode((orderItem.Unit != null) ? orderItem.Unit.Name: "" )%>
        </td>
        <td>
            <%=Html.Encode(orderItem.Price)%>
        </td>
        <td <%= (cartMode) ? "align=\"center\"" : ""%>>
            <%= (cartMode) ? Html.TextBox("quantity_" + orderItem.GetHashCode(), orderItem.Quantity, new { style= "width:12px; font-size:10px;", onblur="tableChanged(items, this)" }) : Html.Encode(orderItem.Quantity)%>
        </td>
        <td>
            <%=Html.Encode(sum.ToString("N"))%>
        </td>
        <%if (cartMode)
          { %>
          <td>
            <%= Html.ResourceActionLink<CartController>("Delete", ac=>ac.RemoveOrderItem(orderItem.GetHashCode()))%>
          </td>
        <%} %>
    </tr>
    <%
        }
            
    %>
    <tr>
        <td colspan="3">
        </td>
        <td>
            <%=Html.ResourceString("Total") %>
        </td>
        <td>
            <%=Html.Encode(Model.OrderItems.Sum(oi=>oi.Quantity))%>
        </td>
        <td>
            <%=Html.Encode(total.ToString("N"))%>
        </td>
        <%if (cartMode){ %>
        <td></td>
        <%} %>
    </tr>
</table>
