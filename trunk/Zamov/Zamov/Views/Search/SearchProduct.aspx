<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.ProductSearchPresentation>>" %>
<%@ Import Namespace="Zamov.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SearchProduct
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script language="javascript" type="text/javascript">
    function AddToCartSuccess(response) {
        $get("totalPrice").innerHTML = response.get_response().get_object().TotalCartPrice;
        $get("orderItemsCount").innerHTML = response.get_response().get_object().TotalCartItems;
        $(".orderCb").attr("checked", "");
        $(".subHeader").css("display", "block");
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

<%--    <div class="subHeader">
        <%
            if (ViewData["TotalCartPrice"] != null)
                Html.Encode(ViewData["TotalCartPrice"].ToString());
        %>
        <% Html.RenderPartial("Cart");  %>
    </div>--%>
    <%
        
        using (Ajax.BeginForm("AddToCart", "Search", new AjaxOptions { HttpMethod = "POST", OnSuccess = "AddToCartSuccess" }, new { id = "addToCart" }))
        {%>

    <table class="commonTable">
        <tr>
            <th><%= Html.ResourceString("Name") %></th>
            <th style="width:20px;"><%= Html.ResourceString("Dealer") %></th>
            <th style="width:20px;"><%= Html.ResourceString("MeassureUnit") %></th>
            <th style="width:20px;"><%= Html.ResourceString("Price") %>, грн.</th>
            <th style="width:20px;"><%= Html.ResourceString("Quantity") %></th>
            <th style="width:20px;"><%= Html.ResourceString("ToOrder") %></th>
        </tr>


       <%     if (Model != null)
                foreach (var item in Model)
                { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Name)%>
            </td>
            <td>
                <%= Html.Encode(item.DealerName)%>
                <%=Html.Hidden("dealer_"+ item.Id,item.DealerId)%>
            </td>
            <td>
                
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.Price))%>
            </td>
            <td align="center">
                <%= Html.TextBox("quantity_" + item.Id, null, new { style = "width:24px; font-size:10px; text-align:center", onkeyup = "validateQuantity(this); order(this)" })%>
            </td>
            <td>
              <%= Html.CheckBox("order_" + item.Id, false, new { @class = "orderCb", onclick = "order(this)" })%>
            </td>
            
        </tr>
    
    <% }
            %>
          

    </table>            
    <input type="submit" value="<%=Html.ResourceString("AddToCart") %>" />  

    <%
        } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

