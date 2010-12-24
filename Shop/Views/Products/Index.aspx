<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Products/Products.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Product>>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if(Roles.IsUserInRole("Administrators")){ %>
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
    
</asp:Content>
