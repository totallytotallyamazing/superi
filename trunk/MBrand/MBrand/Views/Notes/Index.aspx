<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Заметки
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function() { $("#addNote").fancybox({ frameWidth: 750, frameHeight:630, hideOnContentClick: false }) });
    </script>

    <asp:LoginView runat="server">
        <AnonymousTemplate></AnonymousTemplate>
        <LoggedInTemplate>
            <%= Html.ActionLink("Добавить", "AddEditNote", "Admin", new {id = int.MinValue}, new {id = "addNote"}) %>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderTitle" runat="server">
	Заметки
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="Includes">
    <script type="text/javascript" src="/Scripts/jquery.fancybox.js"></script>
    <link rel="Stylesheet" href="/Content/fancy/jquery.fancybox.css" />
</asp:Content>
