<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Подтверждение
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("CartBreadCrumbs", 3); %>

    <div id="basketH"><h1>Все верно?</h1></div>
    <div id="basketBox">
        <div class="section">
        
        <span class="approveTitle">
                Ваш заказ:
        </span>
        <% Html.RenderPartial("OrderItems"); %>
        </div>
        <div class="section">
            <span class="approveTitle">
                Общая стоимость без доставки:
            </span>
            <%= Html.RenderPrice(WebSession.TotalAmount, WebSession.Currency, 0, "," )%>
        </div>
    
        <div class="section">
            <span class="approveTitle">
                Заказ доставляется по адресу:
            </span>
            <%= WebSession.Order.DeliveryAddress %>
        </div>
    </div>

    <div id="nextPreviews">
        <div id="backBox">
            <div id="back"><input alt="Вернуться" src="/Content/img/back.jpg" type="image" onclick="history.back(); return false;" /></div>
        </div>
        <div id="allrightBox2">
            <div id="allright2">
                <% using(Html.BeginForm("SendOrder", "Cart", FormMethod.Get)){ %>
                <input alt="Все правильно" src="/Content/img/allright.jpg" type="image" />
                <div id="heartBasket2">
                    <p><img alt="heart" src="/Content/img/heart.jpg" /></p>
                </div>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.DynamicCssInclude("/Content/Cart.css")%>
</asp:Content>

