<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Product>" %>

<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Name %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if (Roles.IsUserInRole("Administrators"))
       { %>
    <%= Html.ActionLink("Редактировать", "AddEdit", "Products", new { area = "Admin", id = Model.Id, cId = Model.Category.Id, bId = Model.Brand.Id }, null).ToString()%>
    |
    <%= Html.ActionLink("Удалить", "Delete", "Products", new { area = "Admin", id = Model.Id }, new { onclick="return confirm('Вы уверены?')" }).ToString()%>
    <%} %>
    <div id="SlotH">
        <h1>
            Куртка “Roca Wear”</h1>
    </div>
    <div id="SlotProduct">
        <div id="SlotProductFoto">
            <img alt="kurtka" src="img/bigFoto.jpg">
        </div>
        <div id="SlotProductText">
            <p>
                <%= Model.Description %>
            </p>
            <br />
            <p>
                Артикул:<strong><%= Model.PartNumber %></strong></p>
            <br />
            <p>
                Пр-во: <strong>США</strong>
            </p>
            <br />
            <p>
                Размеры:<strong> L, S</strong>
            </p>
            <br />
            <p>
                Состав: <strong>Вискоза, мех.</strong>
            </p>
            <br />
            <p>
                Цена: <strong>1,200 грн</strong></p>
        </div>
        <div id="addToBasket">
            <input alt="Добавить в корзину" src="/Content/img/addToBasket.jpg" type="image">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= Model.Name %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/productSlot.css" />
</asp:Content>
