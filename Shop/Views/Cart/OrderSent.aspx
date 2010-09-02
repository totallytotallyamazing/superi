<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Заявка отправлена
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="orderMade">
      <h1>
        Заявка принята
      </h1>  
      <p>
        С вами свяжется наш менеджер
      </p>
    </div>
    <div class="goHome">
        <a href="/">В каталог</a>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Заявка отправлена
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">  
    <link rel="Stylesheet" href="/Content/orderSent.css" />
</asp:Content>
