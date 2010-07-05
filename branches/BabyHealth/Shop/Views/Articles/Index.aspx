<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Article>>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    

    <% if(Model!=null)
           foreach (var item in Model)
           {
               Html.RenderPartial("Article", item);
           } %>
<div style="clear:both"></div>
<% if(Roles.IsUserInRole("Administrators")){ %>
    <div class="adminLink">
        <%= Html.ActionLink("Создать", "AddEdit", "Articles", new { area="Admin", type=ViewData["type"] }, null)%>
    </div>
<%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.DynamicCssInclude((string)ViewData["css"]) %>
</asp:Content>

