<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.ProductVariant>>" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<table>
    <tr>
        <% foreach (var item in Model.OrderBy(m => m.SortOrder)) 
        {%>
        <td class="productVariant">
            <p class="caption">
                <a id="pv_<%= item.Id %>" imgSource="<%= item.Image %>" >
                    <%: item.Name %>
                </a>
            </p>
            <p class="price">
                <%= Html.RenderPrice(item.Price, WebSession.Currency, 0, ",") %>
            </p>
        </td>
        <%} %>
    </tr>
</table>

<script type="text/javascript">
    ProductVariant.Initialize();
</script>