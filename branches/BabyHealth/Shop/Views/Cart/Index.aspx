<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.OrderItem>>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Корзина
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
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

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>


