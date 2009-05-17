<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Pandemiia.Models.Entity>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Pandemiia.Controllers" %>
<%@ Import Namespace="Pandemiia.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Pandemic
</asp:Content>
<asp:Content ContentPlaceHolderID="AdditionalStylesContent" runat="server">
    <%= Html.RegisterCss("~/Content/entityList.css") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% foreach (var item in Model) { %>
        <% Html.RenderAction<HomeController>(hc => hc.Entity(item)); %>
    <% } %>
</asp:Content>

