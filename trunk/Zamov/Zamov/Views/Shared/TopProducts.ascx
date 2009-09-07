<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Zamov.Models.Product>>" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Helpers" %>
<% 
    List<Product> topProducts = ViewData["topProducts"] as List<Product>;
    if (topProducts.Count > 0)
    {
%>
    

<div class="topProducts">
    <center>
    <span class="header">
        <%= Html.ResourceString("TopProducts").ToUpper() %>
    </span>
    <table class="topProducts" cellspacing="15">
        <tr class="topProduct" align="center">
            <%foreach (Product item in topProducts)
              {%>
              <td>
<%using (Html.BeginForm("AddToCart", "Products", FormMethod.Post)){%>
                <%= Html.Hidden("dealerId", ViewData["dealerId"])%>
                <%= Html.Hidden("groupId", ViewData["groupId"])%>             
                <%= Html.CheckBox("order_" + item.Id, true, new { style="margin-left:-8000px" })%>
                <%= Html.Hidden("quantity_" + item.Id, 1)%>
                <img style="display:block;" alt='<%= item.Name %>' src='/Image/ProductImageDefault/<%= item.Id %>/50' />
                <%= item.Name %><br />
                <span>
                    <%= item.Price.ToString("F") %> грн.
                </span>
<br />
                <input type="submit" value="<%= Html.ResourceString("ToOrder") %>" /><%} %>
              </td>
            <%
                } %>
        </tr>
    </table>
    </center>
</div>
<%} %>
