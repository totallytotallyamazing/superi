<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wasAdded">
        <%= ViewData["name"] %> <asp:Literal runat="server" Text="<%$ Resources:WebResources, WasAdded %>"></asp:Literal>
        <p>
            <%= Html.ResourceActionLink("ReturnToCatalogue", "Index", "Catalogue")%> / <%= Html.ResourceActionLink("ProceedOrder", "Index", "Request")%>
        </p>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>
