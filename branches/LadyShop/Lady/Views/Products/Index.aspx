<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lady.Models.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if(Roles.IsUserInRole("Administrators")){ %>
        <%= Html.ActionLink("Удалить категорию", "Delete", "Categories", new { area = "Admin", id= ViewData["categoryId"]}, null) %>
    <%} %>
    <% if(Model!=null)
           foreach (var item in Model)
           {
               Html.RenderPartial("Product", item);
           } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>
