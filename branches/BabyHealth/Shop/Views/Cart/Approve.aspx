<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Подтверждение
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="section">
        <div class="approveTitle">
            Ваш заказ:
        </div>
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
    
    <div class="backAndForward">
        <div class="back">
            <a href="javascript:history.back();">Вернуться</a>
        </div>
        Все верно, <%= Html.ActionLink("Отправить", "SendOrder") %>
    </div>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <% Html.RenderPartial("CartBreadCrumbs", 3); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

