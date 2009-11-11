<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Сайты
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        » Сайты
    </h2>
    <div style="height:38px;"></div>
    <% Html.RenderPartial("Thumbnails"); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
    Посмотреть
</asp:Content>
