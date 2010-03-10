<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.ResourceString("RequestWasSent")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="information">
        <%= Html.ResourceString("RequestSentMessage")%>    
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= Html.ResourceString("RequestWasSent")%>
</asp:Content>
