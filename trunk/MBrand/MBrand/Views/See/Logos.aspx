<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Логотипы
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="seeContainer">
        <% if(Request.IsAuthenticated){ %>
            <%= Html.ActionLink("Редактировать", "See", "Admin", new { type="Logo" }, new { @class = "adminLink" })%>
        <%} %>
        <% Html.RenderPartial("RandomImage"); %>
    </div>
    <% Html.RenderPartial("SeeMenu"); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
    <script type="text/javascript" src="/Scripts/jquery.fancybox.js"></script>
    <link rel="Stylesheet" href="/Content/fancy/jquery.fancybox.css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
    Посмотреть
</asp:Content>
