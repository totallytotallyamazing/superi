<%@ Page Title="" Language="C#" MasterPageFile="~/Views/DealerCabinet/Cabinet.Master" Inherits="System.Web.Mvc.ViewPage<string>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
<%= Model %>
</asp:Content>
