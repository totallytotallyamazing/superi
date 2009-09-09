<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Zamov.Models.Order>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%
    bool cartMode = (ViewData["cartMode"] != null);
    string caller = ViewData["caller"].ToString();
    //bool requestFromUsercabinet = true;
%>

<script type="text/javascript">
    if (!showOrdershadowsDeclared) {
        $(function() {
            applyDropShadows(".dealerImageLogo", "shadow3");
            $(".productDescription").fancybox({ frameWidth: 700, frameHeight: 500 });
        })
        showOrdershadowsDeclared = true;
    }

    function order(element) {
        var fieldSegments = element.name.split("_");

        var id = fieldSegments[1];

        if (element.type == "checkbox") {
            var input = $get("quantity_" + id);
            if (input.value == "") {
                input.value = 1;
            }
        }
        else {
            var checkbox = $get("order_" + id);
            if (!checkbox.checked) {
                checkbox.checked = true;
            }
        }
    }
    
</script>
<div style="height:120px;">
    <% Html.RenderAction<PagePartsController>(ac => ac.CurrentDealer((int)Model.DealerReference.EntityKey.EntityKeyValues[0].Value)); %>
<%--<%= Html.Image("~/Image/ShowLogo/" + Model.DealerReference.EntityKey.EntityKeyValues[0].Value, new { style="border:1px solid #ccc;", @class="dealerImageLogo" })%>--%>
</div>

<%using(Html.BeginForm("AddToCart","UserCabinet",FormMethod.Post)){ %>
<table class="commonTable">
    <tr>
        <th>
            <%=Html.ResourceString("Title")%>
        </th>
        <th>
            <%=Html.ResourceString("Photo")%>
        </th>
        <th>
            <%=Html.ResourceString("Unit")%>
        </th>
        <th>
            <%=Html.ResourceString("Price")%>
            грн.
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
        <%if (caller == "userCabinet")
          { %>
        <th><%=Html.ResourceString("Quantity")%>/<%=Html.ResourceString("ToOrder")%></th>
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
        <td align="right">
            <%=Html.Encode(orderItem.Price.ToString("N"))%>
        </td>
        <td <%= (cartMode) ? "align=\"center\"" : "align=\"right\""%>>
            <%= (cartMode) ? Html.TextBox("quantity_" + orderItem.GetHashCode(), orderItem.Quantity, new { style= "width:12px; font-size:10px;", onblur="tableChanged(items, this)" }) : Html.Encode(orderItem.Quantity.ToString("N"))%>
        </td>
        <td align="right">
            <%=Html.Encode(sum.ToString("N"))%>
        </td>
        <%if (cartMode)
          { %>
          <td>
            <%= Html.ResourceActionLink<CartController>("Delete", ac=>ac.RemoveOrderItem(orderItem.GetHashCode()))%>
          </td>
        <%} %>
        <%if (caller == "userCabinet")
          { %>
          <td>
          <%= Html.TextBox("quantity_" + orderItem.ProductId, null, new { style = "width:24px; font-size:10px; text-align:center", onkeyup = "validateQuantity(this); order(this)" })%>
          <%= Html.CheckBox("order_" + orderItem.ProductId, false, new { @class = "orderCb", onclick = "order(this)" })%>
          </td>
        <%} %>
    </tr>
    <%
        }
            
    %>
    <tr>
        <td colspan="3">
        </td>
        <td align="center" style="font-weight:bold">
            <%=Html.ResourceString("Total")+":" %>
        </td>
        <td align="center" style="font-weight:bold">
            <%=Html.Encode(Model.OrderItems.Sum(oi=>oi.Quantity).ToString("N"))%>
        </td>
        <td align="right" style="font-weight:bold">
            <%=Html.Encode(total.ToString("N"))%>
        </td>
        <%if (cartMode){ %>
        <td></td>
        <%} %>
        <%if (caller == "userCabinet")
          { %>
        <td></td>
        <%} %>
        
        
    </tr>
</table>
 <%if (caller == "userCabinet")
   { %>
 <input type="submit" value="<%=Html.ResourceString("AddToCart") %>" /> 
 <%} %>

<%} %> 
