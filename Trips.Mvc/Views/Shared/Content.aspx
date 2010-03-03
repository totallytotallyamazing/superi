<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Trips.Mvc.Models.Content>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%if (Model != null) Response.Write(Model.Title); %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if(Request.IsAuthenticated){ %>
        <div class="adminLink">
            <%= Html.ActionLink("Редактировать", "UpdateContent", "Admin", new { id=ViewData["id"]}, null)%>
        </div>
    <%} %>
    <% if (Model != null) Response.Write(Model.Text); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <% if(Model != null){%>
        <meta name="Keywords" content="<%= Model.Keywords %>" />
        <meta name="Description" content="<%= Model.Description %>" />
    <%} %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    <%if (Model != null) Response.Write(Model.Title); %>
</asp:Content>
