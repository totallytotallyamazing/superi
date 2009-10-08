<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Product>>" %>
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
            <th>
                ��������
            </th>
            <th>
                ��������
            </th>
            <th>
                ������� ���������
            </th>
            <th>
                ����
            </th>
            <th>
                ����������
            </th>
            <th>
                ��������
            </th>
        </tr>


       <%     if (Model != null)
                foreach (var item in Model)
                { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Name)%>
            </td>
            <td>
                <%= Html.Encode(item.Dealer.Name)%>
                <%=Html.Hidden("dealer_"+ item.Id,item.Dealer.Id)%>
            </td>
            <td>
                
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.Price))%>
            </td>
            <td>
                
            </td>
            <td>
              <%= Html.CheckBox("order_" + item.Id, false, new { @class="orderCb"})%>
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
