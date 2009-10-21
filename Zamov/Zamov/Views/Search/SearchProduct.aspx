<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.ProductSearchPresentation>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

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

    $(function() {
        $(".productDescription").fancybox({ width: "700px", hideOnContentClick: false });
    })

       
</script>

<%--    <div class="subHeader">
        <%
            if (ViewData["TotalCartPrice"] != null)
                Html.Encode(ViewData["TotalCartPrice"].ToString());
        %>
        <% Html.RenderPartial("Cart");  %>
    </div>--%>
    
    <%

        SortFieldNames? sortFieldName = null;
        SortDirection? sortDirection = null;
        SortDirection? invertSortDirection = null;

        if (ViewData["sortFieldName"] != null && ViewData["sortDirection"] != null)
        {
            sortFieldName = (SortFieldNames)ViewData["sortFieldName"];
            sortDirection = (SortDirection)ViewData["sortDirection"];

            if (sortDirection == SortDirection.Ascending)
                invertSortDirection = SortDirection.Descending;
            else
                invertSortDirection = SortDirection.Ascending;
        }
        
       
    %>
    
    <%
    using (Ajax.BeginForm("AddToCart", "Search", new AjaxOptions { HttpMethod = "POST", OnSuccess = "AddToCartSuccess" }, new { id = "addToCart" }))
    {%>
    <div style="text-align:right">
    <input style="margin-bottom:5px" type="submit" value="<%=Html.ResourceString("AddToCart") %>" />  
    
    <table class="commonTable" width="100%">
        <tr>
            <th>
                <table class="searchTableIneerHeader">
                <tr>
                    <td>
                        <%
                          if (sortFieldName == null)
                          {    
                        %>
                        <%=Html.ResourceActionLink("Name", "SearchProduct", new { sortFieldName = SortFieldNames.Name, sortDirection = SortDirection.Ascending })%>
                        <%}
                          else
                          {%>
                          <%=Html.ResourceActionLink("Name", "SearchProduct", new { sortFieldName = SortFieldNames.Name, sortDirection = invertSortDirection })%>
                        <%} %>
                    </td>
                    <td>
                       <%if (sortFieldName == SortFieldNames.Name)
                         { if (sortDirection == SortDirection.Ascending)
                          {%>
                        <%=Html.Image("~/Content/images/sort_up.gif", new { style = "border-style:none" })%>
                        <%}
                          else
                          { %>
                        <%=Html.Image("~/Content/images/sort_down.gif", new { style = "border-style:none" })%>
                        
                        <%}
                         } %>
                    </td>
                </tr>
                </table>
            </th>
            <th style="width:20px;">
                <table class="searchTableIneerHeader">
                <tr>
                    <td>
                        <%
                          if (sortFieldName == null)
                          {    
                        %>
                        <%=Html.ResourceActionLink("Dealer", "SearchProduct", new { sortFieldName = SortFieldNames.Dealer, sortDirection = SortDirection.Ascending })%>
                        <%}
                          else
                          {%>
                          <%=Html.ResourceActionLink("Dealer", "SearchProduct", new { sortFieldName = SortFieldNames.Dealer, sortDirection = invertSortDirection })%>
                        <%} %>
                    </td>
                    <td>
                       <%if (sortFieldName == SortFieldNames.Dealer)
                         { if (sortDirection == SortDirection.Ascending)
                          {%>
                        <%=Html.Image("~/Content/images/sort_up.gif", new { style = "border-style:none" })%>
                        <%}
                          else
                          { %>
                        <%=Html.Image("~/Content/images/sort_down.gif", new { style = "border-style:none" })%>
                        
                        <%}
                         } %>
                    </td>
                </tr>
                </table>
            </th>
            <th style="width:20px;"><%= Html.ResourceString("MeassureUnit") %></th>
            <th style="width:20px;">
                <table class="searchTableIneerHeader">
                <tr>
                    <td>
                        <%
                          if (sortFieldName == null)
                          {    
                        %>
                        <%=Html.ResourceActionLink("Price", "SearchProduct", new { sortFieldName = SortFieldNames.Price, sortDirection = SortDirection.Ascending })%>, דנם.
                        <%}
                          else
                          {%>
                          <%=Html.ResourceActionLink("Price", "SearchProduct", new { sortFieldName = SortFieldNames.Price, sortDirection = invertSortDirection })%>, דנם.
                        <%} %>
                    </td>
                    <td>
                       <%if (sortFieldName == SortFieldNames.Price)
                         { if (sortDirection == SortDirection.Ascending)
                          {%>
                        <%=Html.Image("~/Content/images/sort_up.gif", new { style = "border-style:none" })%>
                        <%}
                          else
                          { %>
                        <%=Html.Image("~/Content/images/sort_down.gif", new { style = "border-style:none" })%>
                        
                        <%}
                         } %>
                    </td>
                </tr>
                </table>
            </th>
            <th style="width:20px;"><%= Html.ResourceString("Description") %></th>
            <th style="width:20px;"><%= Html.ResourceString("Quantity") %></th>
            <th style="width:20px;"><%= Html.ResourceString("ToOrder") %></th>
        </tr>


       <%     if (Model != null)
                foreach (var item in Model)
                { %>
    
        <tr>
            <td align="left">
                <%= Html.Encode(item.Name)%>
            </td>
            <td align="left">
                <%= Html.Encode(item.DealerName)%>
                <%=Html.Hidden("dealer_"+ item.Id,item.DealerId)%>
            </td>
            <td  align="center">
                <%=Html.Encode(!string.IsNullOrEmpty(item.Unit) ? item.Unit : "רע.")%>
            </td>
            <td  align="right">
                <%= Html.Encode(String.Format("{0:F}", item.Price))%>
            </td>
            <td align="left">
                <a class="productDescription" style="text-decoration:none" href="/Products/Description/<%= item.Id %>">
                    <%= Html.Image("~/Content/img/productImage.JPG", new { style="border:none;" })%> / <span class="productDescriptionLink">i</span>
                </a>
            </td>
            <td align="center">
                <%= Html.TextBox("quantity_" + item.Id, null, new { style = "width:24px; font-size:10px; text-align:center", onkeyup = "validateQuantity(this); order(this)" })%>
            </td>
            <td align="center">
              <%= Html.CheckBox("order_" + item.Id, false, new { @class = "orderCb", onclick = "order(this)" })%>
            </td>
            
        </tr>
    
    <% }
    %>
    </table>            
    <input style="margin-top:5px" type="submit" value="<%=Html.ResourceString("AddToCart") %>" />  
</div>
    <%
        } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterJS("jquery.easing.js")%>
    <%= Html.RegisterJS("jquery.fancybox.js")%>
    <%= Html.RegisterCss("~/Content/fancy/jquery.fancybox.css")%>
    <style type="text/css">
        #leftSide{border:none !important;}
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

