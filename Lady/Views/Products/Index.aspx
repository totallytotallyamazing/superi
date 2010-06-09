﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Products/Products.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if(Roles.IsUserInRole("Administrators") && (bool)ViewData["showAdminLinks"]){ %>
        <% Html.RenderPartial("CategoriesAdmin"); %>
    <%} %>
    <% if(Model!=null)
           foreach (var item in Model)
           {
               Html.RenderPartial("Product", item);
           } %>
           <div style="clear:both"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/catalog.css" />
</asp:Content>
