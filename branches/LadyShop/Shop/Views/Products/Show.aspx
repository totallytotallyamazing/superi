<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Product>" %>

<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Name %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if (Roles.IsUserInRole("Administrators"))
       { %>
       <p class="adminLink">
    <%= Html.ActionLink("Редактировать", "AddEdit", "Products", new { area = "Admin", id = Model.Id, cId = Model.Category.Id, bId = Model.Brand.Id }, null).ToString()%>
    |
    <%= Html.ActionLink("Удалить", "Delete", "Products", new { area = "Admin", id = Model.Id }, new { onclick = "return confirm('Вы уверены?')" }).ToString()%>
    </p>
    <%} %>
    <div id="SlotH">
        <h1>
            Куртка “Roca Wear”</h1>
    </div>

    <div id="SlotProduct">
        <% Html.RenderPartial("ProductImage", Model.ProductImages.Where(m => m.Default).FirstOrDefault()); %>
        <div id="SlotProductText">
            <p>
                <%= Model.Description %>
            </p>
            <p>
                Артикул:<strong><%= Model.PartNumber %></strong>
            </p>
            <% Html.RenderPartial("DetailViewAttributes", Model.ProductAttributeValues); %>    
            <p>
                Цена: <strong><%= Html.RenderPrice(Model.Price, WebSession.Currency, 0, ",") %></strong>
            </p>
        </div>
    </div>
    <% Html.RenderPartial("ImagePreviews", Model.ProductImages.Where(m => !m.Default)); %>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= Model.Name %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/productSlot.css" />
</asp:Content>
