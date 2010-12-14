<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Заказ принят
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="basketH"><h1>Спасибо за заявку!</h1></div>

    <div id="basketBox">
        <div class="acceptWrapper">
            <div class="orderAccepted">
                Ваш заказ принят!
            </div>
            <div class="youWillBeContacted">
                С Вами свяжется наш менеджер.
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.DynamicCssInclude("/Content/Cart.css")%>
</asp:Content>
