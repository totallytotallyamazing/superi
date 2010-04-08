<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= ViewData["content"] %>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="includes">
    <%= Html.RegisterCss("/Content/noLeftMenu.css")%>
</asp:Content>