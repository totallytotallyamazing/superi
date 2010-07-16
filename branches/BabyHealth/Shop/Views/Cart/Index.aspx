<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.OrderItem>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Корзина
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
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
                <%= Html.CachedImage("~/Content/ProductImages", item.Image, "cartThumb", "") %>
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
                <%= Html.TextBox("oi_" + item.ProductId) %>
            </td>
            <td>
                
            </td>
            <td>
            
            </td>
        </tr>
    <%} %>
    </table>
    
    
<%--    
    <table class="productsInCart" cellpadding="5" cellspacing="15">
    <tr>
        <th>
        </th>
        <th>
        </th>
        <th class="quantity">
            Кол-во, шт
        </th>
        <th>
            Стоимость
        </th>
    </tr>
    <% foreach (var item in WebSession.OrderItems){%>
    <tr>
        <td>
            <%= Html.Image("/ImageCache/thumbnail3/" + item.Value.ImageSource) %>
        </td>
        <td class="carData">
            <%= Html.ActionLink(item.Value.AdModel, "Details", "Catalogue", new { id = item.Value.CarId }, null) %><br />
            <span class="adClass">
                <%= Html.ResourceString(((CarAdClasses)item.Value.Class) + "Class") %>
            </span>
        </td>
        <td>
            <%= Html.TextBox("quantity-" + item.Key, item.Value.Quantity) %>
        </td>
        <td>
            <%= Html.ActionLink("[IMAGE]", "DeleteOrderItem", new { id = item.Key })
                                .Replace("[IMAGE]", Html.Image("/Content/img/delete.jpg"))%>
        </td>
    </tr>
    <%} %>
</table>--%>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>


